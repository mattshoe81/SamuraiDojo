using System;
using System.Reflection;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IAttributeUtility
    {
        Attribute GetAttribute(MemberInfo member, Attribute attribute);
        Attribute GetAttribute(Type type, Attribute attribute);
        T GetAttribute<T>(Type type) where T : Attribute;
        bool HasAnyAttribute(MemberInfo member, params Attribute[] attributes);
        bool HasAnyAttribute(Type type, params Attribute[] attributes);
        bool HasAttribute(MemberInfo member, Attribute attribute);
        bool HasAttribute(Type type, Attribute attribute);
        bool HasAttribute<T>(MemberInfo member);
        bool HasAttribute<T>(Type type);
    }
}