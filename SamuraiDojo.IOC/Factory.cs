using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC
{
    public enum BindingConfig
    {
        Singleton,
        Transient,
        Default
    }

    public static class Factory
    {
        private static IDictionary<Type, Type> transientMap;
        private static IDictionary<Type, object> singletonMap;
        private static MultiBindCollection multiBindMap;


        static Factory()
        {
            transientMap = new Dictionary<Type, Type>();
            singletonMap = new Dictionary<Type, object>();
            multiBindMap = new MultiBindCollection();
        }

        /// <summary>
        /// Binds the interface supplied as the generic parameter to the specified 
        /// concrete type. The optional parameter of the method allows you to specify whether
        /// the binding should use the Singleton pattern or create a new instance on each
        /// retrieval. By default, a new instance of the concrete type will be created on 
        /// every retrieval.
        /// </summary>
        /// <typeparam name="T">Interface to which an implementation will be bound</typeparam>
        /// <param name="type">Concrete type used for instantiation</param>
        public static void Bind<T>(Type concreteType, BindingConfig config = BindingConfig.Default)
        {
            ValidateBinding<T>("Factory.Bind", concreteType);

            switch (config)
            {
                case BindingConfig.Singleton:
                    BindSingleton<T>(concreteType);
                    break;
                case BindingConfig.Transient:
                    BindTransient<T>(concreteType);
                    break;
                default:
                    BindDefault<T>(concreteType);
                    break;
            }
        }

        /// <summary>
        /// Allows you to bind multiple concrete types to a single interface by specifying a
        /// unique string key for each implementation. The interface type is supplied as the
        /// generic parameter. The concrete type must be accompanied by a unique key by which
        /// it will be retrieved for instantiation. The optional parameter allows you to specify
        /// whether the concrete type will be bound as a Singleton or not. By default, the concrete
        /// type will be newly instantiated on every retrieval unless you specify otherwise.
        /// </summary>
        /// <typeparam name="T">The interface to which an implementation will be bound</typeparam>
        /// <param name="key">The unique identifier for an implementation</param>
        /// <param name="concreteType">The concrete type being bound to the interface</param>
        public static void MultiBind<T>(string key, Type concreteType, BindingConfig config = BindingConfig.Default)
        {
            ValidateBinding<T>("Factory.MultiBind", concreteType);

            multiBindMap.Bind<T>(key, concreteType, config);
        }

        /// <summary>
        /// Create a new instance of the concrete type that is bound to the specified 
        /// interface.
        /// </summary>
        /// <typeparam name="T">The interface for which a concrete type will be instantiated.</typeparam>
        /// <returns>An instance of the concrete type bound to the specified interface.</returns>
        public static T Get<T>(BindingConfig config = BindingConfig.Default)
        {
            AssertInterface<T>("Factory.New");

            T result;
            Type interfaceType = typeof(T);
            switch (config)
            {
                case BindingConfig.Singleton:
                    result = (T)singletonMap[interfaceType];
                    break;
                case BindingConfig.Transient:
                    // Let this fall through for now
                default:
                    result = (T)ResolveDefault(interfaceType);
                    break;
            }            

            return result;
        }

        /// <summary>
        /// Retrieves an instance of the type bound to the specified interface based on its
        /// unique key. This is how you retrieve a multibound concrete type. Just provide 
        /// the interface type and the key you provided during binding. The optional 
        /// parameter allows you to force theretrieval of a singleton or instance binding, 
        /// in case you have multibound the same interface to both a singleton and an 
        /// instance. By default, the method will check for a singleton first, if none is 
        /// found, then an instance is returned.
        /// </summary>
        /// <typeparam name="T">The interface type to which a concrete type is multibound</typeparam>
        /// <param name="multiBindKey">The key used to identify a particular multibinding</param>
        /// <returns>A concrete instance of the specified multibound interface type</returns>
        public static T Get<T>(string multiBindKey, BindingConfig config = BindingConfig.Default)
        {
            AssertInterface<T>("Factory.New");

            T instance = multiBindMap.Get<T>(multiBindKey, config);
            return instance;
        }

        /// <summary>
        /// Clears all bindings and dependencies.
        /// </summary>
        public static void Reset()
        {
            transientMap.Clear();
            singletonMap.Clear();

        }

        private static void ValidateBinding<T>(string methodName, Type type)
        {
            AssertInterface<T>(methodName);
            AssertImplementation<T>(methodName, type);
        }

        private static void AssertInterface<T>(string methodName)
        {
            if (!typeof(T).IsInterface)
                throw new InvalidCastException($"Generic type parameter for {methodName} must be an interface.");
        }

        private static void AssertImplementation<T>(string methodName, Type concreteType)
        {
            if (concreteType.IsInterface)
                throw new InvalidCastException($"Concrete type for {methodName} must NOT be an interface.");

            bool implementsInterface = typeof(T).IsAssignableFrom(concreteType);
            if (!implementsInterface)
                throw new InvalidCastException($"Concrete type does not implement the specified interface.");
        }

        private static void BindDefault<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (singletonMap.ContainsKey(interfaceType))
                BindSingleton<T>(concreteType);
            else if (transientMap.ContainsKey(interfaceType))
                BindTransient<T>(concreteType);
            else
                transientMap.Add(interfaceType, concreteType);
        }

        private static void BindSingleton<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);
            T singleton = (T)Activator.CreateInstance(concreteType);

            if (singletonMap.ContainsKey(interfaceType))
                singletonMap[interfaceType] = singleton;
            else
                singletonMap.Add(interfaceType, singleton);
        }

        private static void BindTransient<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (transientMap.ContainsKey(interfaceType))
                transientMap[interfaceType] = concreteType;
            else
                transientMap.Add(interfaceType, concreteType);
        }

        private static T ResolveSingleton<T>()
        {

            return default(T);
        }

        private static object ResolveDefault(Type interfaceType)
        {
            Type concreteType = transientMap[interfaceType];
            ConstructorInfo[] constructors = concreteType.GetConstructors();
            object instance = default;
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

            if (instance == default || instance == null)
                throw new InvalidOperationException($"Unable to resolve dependencies for {interfaceType.FullName} and it has no parameterless constructor.");

            return instance;
        }

        private static object ResolveConstructor(ConstructorInfo constructor)
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

        private static object[] ResolveParameters(ParameterInfo[] parameterDefinitions)
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

                    parameter = ResolveDefault(parameterType);
                    parameters[i] = parameter;
                }
                catch
                {
                    break;
                }
            }

            return parameters;
        }

        private static T ResolveDefault<T>()
        {


            return default(T);
        }
    }
}
