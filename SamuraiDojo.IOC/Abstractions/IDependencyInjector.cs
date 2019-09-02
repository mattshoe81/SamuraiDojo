using System;

namespace SamuraiDojo.IoC.Abstractions
{
    internal interface IDependencyInjector
    {
        object ResolveConcrete(Type concreteType);
        object ResolveInterface(Type interfaceType);
    }
}