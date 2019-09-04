using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.IoC
{
    public class DependentAssemblyCollection : ConfigurationElementCollection
    {
        public DependentAssemblyElement this[int index]
        {
            get => BaseGet(index) as DependentAssemblyElement;
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DependentAssemblyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DependentAssemblyElement)element).Name;
        }
    }
}
