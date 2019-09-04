using System;
using System.Collections.Generic;
using SamuraiDojo.IoC.DependencyManagement.Interfaces;

namespace SamuraiDojo.IoC.DependencyManagement
{
    internal class DependencyRepository : IDependencyRepository
    {
        public IDictionary<Type, Type> Transient { get; set; }

        public IDictionary<Type, object> Singleton { get; set; }

        public DependencyRepository()
        {
            Transient = new Dictionary<Type, Type>();
            Singleton = new Dictionary<Type, object>();
        }
    }
}
