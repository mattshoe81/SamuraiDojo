using System;
using SamuraiDojo.IoC.DependencyManagement;
using SamuraiDojo.IoC.DependencyManagement.Interfaces;

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
        private static readonly IMultiBindCollection multiBindMap;
        private static readonly IDependencyRepository dependencies;
        private static readonly IDependencyInjector injector;
        
        static Factory()
        {
            multiBindMap = InternalFactory.Get<IMultiBindCollection>();
            dependencies = InternalFactory.Get<IDependencyRepository>();
            injector = InternalFactory.Get<IDependencyInjector>();
        }

        /// <summary>
        /// Get an instance of the concrete type that is bound to the specified interface.
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
                    result = (T)dependencies.Singleton[interfaceType];
                    break;
                case BindingConfig.Transient:
                // Let this fall through for now
                default:
                    result = (T)injector.ResolveInterface(interfaceType);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Retrieves an instance of the type bound to the specified interface based on its
        /// unique key. This is how you retrieve a multibound concrete type. Just provide 
        /// the interface type and the key you provided during binding. The optional 
        /// parameter allows you to force the retrieval of a singleton or instance binding, 
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

        private static void AssertInterface<T>(string methodName)
        {
            if (!(typeof(T).IsInterface || typeof(T).IsAbstract))
                throw new InvalidCastException($"Generic type parameter for {methodName} must be an interface or an abstract class.");
        }
    }
}
