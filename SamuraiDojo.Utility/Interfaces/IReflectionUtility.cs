using System;
using System.Collections.Generic;
using System.Reflection;

namespace SamuraiDojo.Utility.Interfaces
{
    public interface IReflectionUtility
    {
        object GetInstance(Type type);
        List<MethodInfo> GetMethodsWithAnyAttribute(Type type, params Attribute[] attributes);
        List<MethodInfo> GetMethodsWithAttribute<T>(Type type);
        Type[] GetSubTypes<T>(string assemblyName);
        Type[] LoadTypes(string assemblyName);
        Type[] LoadTypesWithAnyAttribute(string assemblyName, params Attribute[] attributes);
        Type[] LoadTypesWithAttribute<T>(string assemblyName) where T : Attribute;
    }
}