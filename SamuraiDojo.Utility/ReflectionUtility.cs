using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Utility
{
    public class ReflectionUtility
    {
        public static T GetInstance<T>()
        {
            T instance = default;
            try
            {
                instance = Activator.CreateInstance<T>();
            } 
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

            return instance;
        }
        public static object GetInstance(Type type)
        {
            object instance = default;
            try
            {
                instance = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

            return instance;
        }

        public static Type[] LoadTypes(string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type[] types = assembly.GetTypes();
            return types;
        }

        public static Type[] LoadTypesWithAttribute<T>(string assemblyName)
            where T : Attribute
        {
            Type[] types = LoadTypes(assemblyName);
            types = types.Where((clazz) => AttributeUtility.HasAttribute<T>(clazz)).ToArray();

            return types;
        }

        public static Type[] LoadTypesWithAnyAttribute(string assemblyName, params Attribute[] attributes)
        {
            Type[] types = LoadTypes(assemblyName);
            types = types.Where((clazz) => AttributeUtility.HasAnyAttribute(clazz, attributes)).ToArray();

            return types;
        }

        public static Type[] GetSubTypes<T>(string assemblyName)
        {
            Type[] allTypes = LoadTypes(assemblyName);
            Type[] subTypes = allTypes.Where(type => typeof(T).IsAssignableFrom(type) && type != typeof(T)).ToArray();

            return subTypes;
        }

        public static List<MethodInfo> GetMethodsWithAttribute<T>(Type type)
        {
            MethodInfo[] allMethods = type.GetMethods();
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (MethodInfo method in allMethods)
            {
                if (AttributeUtility.HasAttribute<T>(method))
                    methods.Add(method);
            }

            return methods;
        }

        public static List<MethodInfo> GetMethodsWithAnyAttribute(Type type, params Attribute[] attributes)
        {
            MethodInfo[] allMethods = type.GetMethods();
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (MethodInfo method in allMethods)
            {
                if (AttributeUtility.HasAnyAttribute(method, attributes))
                    methods.Add(method);
            }

            return methods;
        }
    }
}
