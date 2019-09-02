using System;

namespace SamuraiDojo.IoC.Abstractions
{
    internal interface IMultiBindCollection
    {
        void Bind<T>(string key, Type concreteType, BindingConfig config = BindingConfig.Default);
        void Clear();
        T Get<T>(string key, BindingConfig config = BindingConfig.Default);
    }
}