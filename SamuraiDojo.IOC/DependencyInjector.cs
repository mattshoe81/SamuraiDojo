using System;
using System.Linq;
using System.Reflection;
using SamuraiDojo.IoC.Abstractions;

namespace SamuraiDojo.IoC
{
    internal class DependencyInjector : IDependencyInjector
    {
        private IDependencyRepository dependencies;

        public DependencyInjector(IDependencyRepository dependencies)
        {
            this.dependencies = dependencies;
        }


        public object ResolveInterface(Type interfaceType)
        {
            object instance = default;

            // No need to resolve if we have a singleton
            if (dependencies.Singleton.ContainsKey(interfaceType))
                instance = dependencies.Singleton[interfaceType];
            else if (dependencies.Transient.ContainsKey(interfaceType))
            {
                Type concreteType = dependencies.Transient[interfaceType];
                instance = ResolveConcrete(concreteType);

                if (instance == default || instance == null)
                    throw new InvalidOperationException($"Unable to resolve dependencies for {interfaceType.FullName} and it has no parameterless constructor.");
            }

            return instance;
        }

        public object ResolveConcrete(Type concreteType)
        {
            object instance = default;

            ConstructorInfo[] constructors = concreteType.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                instance = ResolveConstructor(constructor);
                if (instance != null)
                    break;
            }

            if (instance == default || instance == null)
            {
                ConstructorInfo emptyConstructor = constructors?.Where(constructor => constructor.GetParameters().Length == 0).FirstOrDefault();
                instance = emptyConstructor?.Invoke(new object[0]);
            }

            return instance;
        }

        private object ResolveConstructor(ConstructorInfo constructor)
        {
            object instance = default;
            ParameterInfo[] parameterDefinitions = constructor.GetParameters();
            if (parameterDefinitions.Length == 0)
                return instance;

            object[] parameters = ResolveParameters(parameterDefinitions);

            // If any params are null then we couldn't resolve
            if (!parameters.Any(param => param == default || param == null))
                instance = constructor.Invoke(parameters);

            return instance;
        }

        private object[] ResolveParameters(ParameterInfo[] parameterDefinitions)
        {
            object[] parameters = new object[parameterDefinitions.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                object parameter = default;
                try
                {
                    Type parameterType = parameterDefinitions[i].ParameterType;
                    if (!parameterType.IsInterface)
                        throw new Exception();

                    // Recursively resolve each parameter
                    parameter = ResolveInterface(parameterType);
                    parameters[i] = parameter;
                }
                catch
                {
                    break;
                }
            }

            return parameters;
        }
    }
}
