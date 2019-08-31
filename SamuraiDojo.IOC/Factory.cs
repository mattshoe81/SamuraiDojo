using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IOC
{
    public static class Factory
    {
        public enum Pattern
        {
            SINGLETON
        }

        private static IDictionary<Type, Type> typeMap;

        private static IDictionary<Type, object> singletons;

        private static MultiBindCollection multiBindMap;


        static Factory()
        {
            typeMap = new Dictionary<Type, Type>();
            multiBindMap = new MultiBindCollection();
            singletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Binds the interface supplied as the generic parameter to the specified 
        /// concrete type.
        /// </summary>
        /// <typeparam name="T">Interface to which an implementation will be bound</typeparam>
        /// <param name="type">Concrete type used for instantiation</param>
        public static void Bind<T>(Type type)
        {
            AssertInterface<T>("Factory.Bind");
            AssertImplementation("Factory.Bind", type);

            typeMap.Add(typeof(T), type);
        }

        public static void BindSingleton<T>(Type type)
        {
            AssertInterface<T>("Factory.BindSingleton");
            AssertImplementation("Factory.BindSingleton", type);

            T instance = (T)Activator.CreateInstance(type);
            singletons.Add(typeof(T), instance);
        }

        /// <summary>
        /// Allows you to bind multiple concrete types to a single interface by specifying a
        /// unique string key for each implementation. The interface type is supplied as the
        /// generic parameter. The concrete type must be accompanied by a unique key by which
        /// it will be retrieved for instantiation. 
        /// </summary>
        /// <typeparam name="T">The interface to which an implementation will be bound</typeparam>
        /// <param name="key">The unique identifier for an implementation</param>
        /// <param name="type">The concrete type being bound to the interface</param>
        public static void MultiBind<T>(string key, Type type)
        {
            AssertInterface<T>("Factory.MultiBind");
            AssertImplementation("Factory.MultiBind", type);

            multiBindMap.Bind<T>(key, type);
        }

        public static void Bind<T>(Type type, Pattern pattern)
        {
            switch (pattern)
            {
                case Pattern.SINGLETON:
                    break;
            }
        }

        /// <summary>
        /// Create a new instance of the concrete type that is bound to the specified 
        /// interface.
        /// </summary>
        /// <typeparam name="T">The interface for which a concrete type will be instantiated.</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            AssertInterface<T>("Factory.New");

            T instance;
            if (singletons.ContainsKey(typeof(T)))
                instance = (T)singletons[typeof(T)];
            else
                instance = (T)Activator.CreateInstance(typeMap[typeof(T)]);

            return instance;
        }

        /// <summary>
        /// Create a new instance of the type bound to the specified interface based on its
        /// unique key. This is how you retrieve an implementation of an interface to which
        /// you have bound multiple concrete types. Just provide the interface type and the
        /// key you provided during binding.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="multiBindKey"></param>
        /// <returns></returns>
        public static T New<T>(string multiBindKey)
        {
            AssertInterface<T>("Factory.New");

            T instance = (T)Activator.CreateInstance(multiBindMap.Get<T>(multiBindKey));
            return instance;
        }

        public static T Singleton<T>()
        {
            return (T)singletons[typeof(T)];
        }

        private static void AssertInterface<T>(string methodName)
        {
            if (!typeof(T).IsInterface)
                throw new InvalidCastException($"Generic type parameter for {methodName} must be an interface.");
        }

        private static void AssertImplementation(string methodName, Type type)
        {
            if (type.IsInterface)
                throw new InvalidCastException($"Implementation type for {methodName} must NOT be an interface.");
        }
    }
}
