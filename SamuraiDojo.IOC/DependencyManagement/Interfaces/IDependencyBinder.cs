using System;

namespace SamuraiDojo.IoC.DependencyManagement.Interfaces
{
    internal interface IDependencyBinder
    {
        void Bind<T>(Type concreteType, BindingConfig config = BindingConfig.Default);
        void Debind(Type interfaceType, BindingConfig config = BindingConfig.Default);
        void Debind<T>(BindingConfig config = BindingConfig.Default);
        void Resolve();
    }
}