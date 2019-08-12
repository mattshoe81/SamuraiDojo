using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Utility
{
    public class AttributeUtility
    {

        public static bool HasAttribute<T>(Type type)
        {
            bool result;
            try
            {
                Attribute attribute = Attribute.GetCustomAttribute(type, typeof(T));
                result = attribute != null;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static bool HasAttribute<T>(MemberInfo member)
        {
            bool result;
            try
            {
                Attribute attribute = Attribute.GetCustomAttribute(member, typeof(T));
                result = attribute != null;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static T GetAttribute<T>(Type type) where T : Attribute
        {
            T attribute;
            try
            {
                attribute = (T)Attribute.GetCustomAttribute(type, typeof(T));
            }
            catch
            {
                attribute = null;
            }

            return attribute;
        }

        public static Attribute GetAttribute(Type type, Attribute attribute)
        {
            Attribute result;
            try
            {
                result = Attribute.GetCustomAttribute(type, attribute.GetType());
            }
            catch
            {
                result = null;
            }

            return result;
        }
        
        public static Attribute GetAttribute(MemberInfo member, Attribute attribute)
        {
            Attribute result;
            try
            {
                result = Attribute.GetCustomAttribute(member, attribute.GetType());
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public static bool HasAttribute(Type type, Attribute attribute)
        {
            return GetAttribute(type, attribute) != null;
        }

        public static bool HasAttribute(MemberInfo member, Attribute attribute)
        {
            return GetAttribute(member, attribute) != null;
        }

        public static bool HasAnyAttribute(Type type, params Attribute[] attributes)
        {
            foreach (Attribute attribute in attributes)
            {
                if (HasAttribute(type, attribute))
                    return true;
            }

            return false;
        }

        public static bool HasAnyAttribute(MemberInfo member, params Attribute[] attributes)
        {
            foreach (Attribute attribute in attributes)
            {
                if (HasAttribute(member, attribute))
                    return true;
            }

            return false;
        }
    }
}
