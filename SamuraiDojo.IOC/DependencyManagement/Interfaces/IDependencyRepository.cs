using System;
using System.Collections.Generic;

namespace SamuraiDojo.IoC.DependencyManagement.Interfaces
{
    internal interface IDependencyRepository
    {
        IDictionary<Type, object> Singleton { get; set; }
        IDictionary<Type, Type> Transient { get; set; }
    }
}