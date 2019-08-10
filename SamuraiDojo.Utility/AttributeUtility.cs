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
    }
}
