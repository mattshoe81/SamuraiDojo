using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC
{
    public enum BindingConfig
    {
        SINGLETON,
        INSTANCE,
        DEFAULT
    }

    public static class Factory
    {
        private static IDictionary<Type, Type> instanceMap;
        private static IDictionary<Type, object> singletonMap;
        private static MultiBindCollection multiBindMap;


        static Factory()
        {
            instanceMap = new Dictionary<Type, Type>();
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
        public static void Bind<T>(Type concreteType, BindingConfig config = BindingConfig.DEFAULT)
        {
            ValidateBinding<T>("Factory.Bind", concreteType);

            switch (config)
            {
                case BindingConfig.SINGLETON:
                    BindSingleton<T>(concreteType);
                    break;
                case BindingConfig.INSTANCE:
                    BindInstance<T>(concreteType);
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
        public static void MultiBind<T>(string key, Type concreteType, BindingConfig config = BindingConfig.DEFAULT)
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
        public static T Get<T>(BindingConfig config = BindingConfig.DEFAULT)
        {
            AssertInterface<T>("Factory.New");

            T result;
            Type interfaceType = typeof(T);
            switch (config)
            {
                case BindingConfig.SINGLETON:
                    result = (T)singletonMap[interfaceType];
                    break;
                case BindingConfig.INSTANCE:
                    result = (T)Activator.CreateInstance(instanceMap[interfaceType]);
                    break;
                default:
                    if (singletonMap.ContainsKey(typeof(T)))
                        result = (T)singletonMap[typeof(T)];
                    else
                        result = (T)Activator.CreateInstance(instanceMap[typeof(T)]);
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
        public static T Get<T>(string multiBindKey, BindingConfig config = BindingConfig.DEFAULT)
        {
            AssertInterface<T>("Factory.New");

            T instance = multiBindMap.Get<T>(multiBindKey, config);
            return instance;
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
            if (!(concreteType is T))
                throw new InvalidCastException($"Concrete type does not implement the specified interface.");
        }

        private static void BindDefault<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (singletonMap.ContainsKey(interfaceType))
                BindSingleton<T>(concreteType);
            else if (instanceMap.ContainsKey(interfaceType))
                BindInstance<T>(concreteType);
            else
                instanceMap.Add(interfaceType, concreteType);
        }

        private static void BindSingleton<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (singletonMap.ContainsKey(interfaceType))
                singletonMap[interfaceType] = (T)Activator.CreateInstance(concreteType);
            else
                singletonMap.Add(interfaceType, concreteType);
        }

        private static void BindInstance<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (instanceMap.ContainsKey(interfaceType))
                instanceMap[interfaceType] = concreteType;
            else
                instanceMap.Add(interfaceType, concreteType);
        }
    }
}
