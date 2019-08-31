using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IOC
{
    internal class MultiBindCollection
    {
        private Dictionary<Type, Dictionary<string, Type>> multiBinds;

        public MultiBindCollection()
        {
            multiBinds = new Dictionary<Type, Dictionary<string, Type>>();
        }

        public void Bind<T>(string key, Type type)
        {
            if (multiBinds.ContainsKey(typeof(T)))
                multiBinds[typeof(T)].Add(key, type);
            else
                multiBinds.Add(typeof(T), new Dictionary<string, Type> { { key, type } });
        }

        public Type Get<T>(string key)
        {
            return multiBinds[typeof(T)][key];
        }
    }
}
