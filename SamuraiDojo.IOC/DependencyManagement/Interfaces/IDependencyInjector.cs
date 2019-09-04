using System;

namespace SamuraiDojo.IoC.DependencyManagement.Interfaces
{
    internal interface IDependencyInjector
    {
        object ResolveConcrete(Type concreteType);
        object ResolveInterface(Type interfaceType);
    }
}