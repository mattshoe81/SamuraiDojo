using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.DependencyManagement;
using SamuraiDojo.IoC.DependencyManagement.Interfaces;

namespace SamuraiDojo.IoC
{
    internal static class InternalFactory
    {
        private static IDictionary<Type, object> singletons;

        static InternalFactory()
        {
            IDependencyRepository dependencies = new DependencyRepository();
            IDependencyInjector injector = new DependencyInjector(dependencies);
            IDependencyBinder binder = new DependencyBinder(dependencies, injector);
            IMultiBindCollection multiBindMap = new MultiBindCollection();

            singletons = new Dictionary<Type, object>
            {
                { typeof(IDependencyRepository), dependencies },
                { typeof(IDependencyInjector), injector },
                { typeof(IDependencyBinder), binder },
                { typeof(IMultiBindCollection), multiBindMap },
            };
        }

        public static T Get<T>()
        {
            Type interfaceType = typeof(T);
            object instance = singletons[interfaceType];

            return (T)instance;
        }
    }
}
