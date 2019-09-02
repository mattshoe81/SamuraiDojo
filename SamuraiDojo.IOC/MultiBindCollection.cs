using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.Abstractions;

namespace SamuraiDojo.IoC
{
    internal class MultiBindCollection : IMultiBindCollection
    {
        private Dictionary<Type, Dictionary<string, object>> singletonMultiBinds;
        private Dictionary<Type, Dictionary<string, Type>> transientMultiBinds;

        public MultiBindCollection()
        {
            singletonMultiBinds = new Dictionary<Type, Dictionary<string, object>>();
            transientMultiBinds = new Dictionary<Type, Dictionary<string, Type>>();
        }

        public void Bind<T>(string key, Type concreteType, BindingConfig config = BindingConfig.Default)
        {
            switch (config)
            {
                case BindingConfig.Singleton:
                    BindSingleton<T>(key, concreteType);
                    break;
                case BindingConfig.Transient:
                    BindTransient<T>(key, concreteType);
                    break;
                default:
                    BindDefault<T>(key, concreteType);
                    break;
            }
        }

        public T Get<T>(string key, BindingConfig config = BindingConfig.Default)
        {
            T result;

            switch (config)
            {
                case BindingConfig.Singleton:
                    result = GetSingleton<T>(key);
                    break;
                case BindingConfig.Transient:
                    result = GetTransient<T>(key);
                    break;
                default:
                    result = GetDefault<T>(key);
                    break;
            }

            return result;
        }

        public void Clear()
        {
            transientMultiBinds.Clear();
            singletonMultiBinds.Clear();
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

        private void BindTransient<T>(string key, Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (transientMultiBinds.ContainsKey(interfaceType))
            {
                Dictionary<string, Type> multiBinds = transientMultiBinds[interfaceType];
                if (multiBinds.ContainsKey(key))
                    multiBinds[key] = concreteType;
                else
                    multiBinds.Add(key, concreteType);
            }
            else
                transientMultiBinds.Add(interfaceType, new Dictionary<string, Type> { { key, concreteType } });
        }

        private void BindDefault<T>(string key, Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (singletonMultiBinds.ContainsKey(interfaceType))
                BindSingleton<T>(key, concreteType);
            else
                BindTransient<T>(key, concreteType);
        }

        private T GetSingleton<T>(string key)
        {
            Type interfaceType = typeof(T);

            return (T)singletonMultiBinds[interfaceType][key];
        }

        private T GetTransient<T>(string key)
        {
            Type interfaceType = typeof(T);
            Type concreteType = transientMultiBinds[interfaceType][key];
            return (T)Activator.CreateInstance(concreteType);
        }

        private T GetDefault<T>(string key)
        {
            Type interfaceType = typeof(T);
            T instance;
            if (singletonMultiBinds.ContainsKey(interfaceType))
                instance = GetSingleton<T>(key);
            else
                instance = GetTransient<T>(key);

            return instance;
        }
    }
}
