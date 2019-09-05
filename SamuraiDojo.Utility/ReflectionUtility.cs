using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.Utility
{
    internal class ReflectionUtility : IReflectionUtility
    {
        private IAttributeUtility attributeUtility;
        private ILog log;

        public ReflectionUtility(IAttributeUtility attributeUtility, ILog log)
        {
            this.attributeUtility = attributeUtility;
            this.log = log;
        }

        public object GetInstance(Type type)
        {
            object instance = default;
            try
            {
                instance = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }

            return instance;
        }

        public Type[] LoadTypes(string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type[] types = assembly.GetTypes();
            return types;
        }

        public Type[] LoadTypesWithAttribute<T>(string assemblyName)
            where T : Attribute
        {
            Type[] types = LoadTypes(assemblyName);
            types = types.Where((clazz) => attributeUtility.HasAttribute<T>(clazz)).ToArray();

            return types;
        }

        public Type[] LoadTypesWithAnyAttribute(string assemblyName, params Attribute[] attributes)
        {
            Type[] types = LoadTypes(assemblyName);
            types = types.Where((clazz) => attributeUtility.HasAnyAttribute(clazz, attributes)).ToArray();

            return types;
        }

        public Type[] GetSubTypes<T>(string assemblyName)
        {
            Type[] allTypes = LoadTypes(assemblyName);
            Type[] subTypes = allTypes.Where(type => typeof(T).IsAssignableFrom(type) && type != typeof(T)).ToArray();

            return subTypes;
        }

        public List<MethodInfo> GetMethodsWithAttribute<T>(Type type)
        {
            MethodInfo[] allMethods = type.GetMethods();
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (MethodInfo method in allMethods)
            {
                if (attributeUtility.HasAttribute<T>(method))
                    methods.Add(method);
            }

            return methods;
        }

        public List<MethodInfo> GetMethodsWithAnyAttribute(Type type, params Attribute[] attributes)
        {
            MethodInfo[] allMethods = type.GetMethods();
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (MethodInfo method in allMethods)
            {
                if (attributeUtility.HasAnyAttribute(method, attributes))
                    methods.Add(method);
            }

            return methods;
        }
    }
}
