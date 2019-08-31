using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC
{
    internal class MultiBindCollection
    {
        private Dictionary<Type, Dictionary<string, object>> singletonMultiBinds;
        private Dictionary<Type, Dictionary<string, Type>> instanceMultiBinds;

        public MultiBindCollection()
        {
            singletonMultiBinds = new Dictionary<Type, Dictionary<string, object>>();
            instanceMultiBinds = new Dictionary<Type, Dictionary<string, Type>>();
        }

        public void Bind<T>(string key, Type concreteType, BindingConfig config = BindingConfig.DEFAULT)
        {
            switch (config)
            {
                case BindingConfig.SINGLETON:
                    BindSingleton<T>(key, concreteType);
                    break;
                case BindingConfig.INSTANCE:
                    BindInstance<T>(key, concreteType);
                    break;
                default:
                    BindDefault<T>(key, concreteType);
                    break;
            }
        }

        public T Get<T>(string key, BindingConfig config = BindingConfig.DEFAULT)
        {
            T result;
            
            switch (config)
            {
                case BindingConfig.SINGLETON:
                    result = GetSingleton<T>(key);
                    break;
                case BindingConfig.INSTANCE:
                    result = GetInstance<T>(key);
                    break;
                default:
                    result = GetDefault<T>(key);
                    break;
            }

            return result;
        }

        private void BindSingleton<T>(string key, Type concreteType)
        {
            Type interfaceType = typeof(T);
            T singleton = (T)Activator.CreateInstance(concreteType);

            if (singletonMultiBinds.ContainsKey(interfaceType))
            {
                Dictionary<string, object> multiBinds = singletonMultiBinds[interfaceType];
                if (multiBinds.ContainsKey(key))
                    multiBinds[key] = singleton;
                else
                    multiBinds.Add(key, singleton);
            }
            else
                singletonMultiBinds.Add(interfaceType, new Dictionary<string, object> { { key, singleton } });
        }

        private void BindInstance<T>(string key, Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (instanceMultiBinds.ContainsKey(interfaceType))
            {
                Dictionary<string, Type> multiBinds = instanceMultiBinds[interfaceType];
                if (multiBinds.ContainsKey(key))
                    multiBinds[key] = concreteType;
                else
                    multiBinds.Add(key, concreteType);
            }
            else
                instanceMultiBinds.Add(interfaceType, new Dictionary<string, Type> { { key, concreteType } });
        }

        private void BindDefault<T>(string key, Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (singletonMultiBinds.ContainsKey(interfaceType))
                BindSingleton<T>(key, concreteType);
            else
                BindInstance<T>(key, concreteType);
        }

        private T GetSingleton<T>(string key)
        {
            Type interfaceType = typeof(T);

            return (T)singletonMultiBinds[interfaceType][key];
        }

        private T GetInstance<T>(string key)
        {
            Type interfaceType = typeof(T);
            Type concreteType = instanceMultiBinds[interfaceType][key];
            return (T)Activator.CreateInstance(concreteType);
        }

        private T GetDefault<T>(string key)
        {
            Type interfaceType = typeof(T);
            T instance;
            if (singletonMultiBinds.ContainsKey(interfaceType))
                instance = GetSingleton<T>(key);
            else
                instance = GetInstance<T>(key);

            return instance;
        }
    }
}
