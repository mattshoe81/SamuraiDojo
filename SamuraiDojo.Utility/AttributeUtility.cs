using System;
using System.Reflection;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Utility
{
    public class AttributeUtility : IAttributeUtility
    {
        private ILog log;

        public AttributeUtility(ILog log)
        {
            this.log = log;
        }

        public bool HasAttribute<T>(Type type)
        {
            bool result;
            try
            {
                Attribute attribute = Attribute.GetCustomAttribute(type, typeof(T));
                result = attribute != null;
            }
            catch (Exception ex)
            {
                LogException(ex);
                result = false;
            }

            return result;
        }

        public bool HasAttribute<T>(MemberInfo member)
        {
            bool result;
            try
            {
                Attribute attribute = Attribute.GetCustomAttribute(member, typeof(T));
                result = attribute != null;
            }
            catch (Exception ex)
            {
                LogException(ex);
                result = false;
            }

            return result;
        }

        public T GetAttribute<T>(Type type) where T : Attribute
        {
            T attribute;
            try
            {
                attribute = (T)Attribute.GetCustomAttribute(type, typeof(T));
            }
            catch (Exception ex)
            {
                LogException(ex);
                attribute = null;
            }

            return attribute;
        }

        public Attribute GetAttribute(Type type, Attribute attribute)
        {
            Attribute result;
            try
            {
                result = Attribute.GetCustomAttribute(type, attribute.GetType());
            }
            catch (Exception ex)
            {
                LogException(ex);
                result = null;
            }

            return result;
        }

        public Attribute GetAttribute(MemberInfo member, Attribute attribute)
        {
            Attribute result;
            try
            {
                result = Attribute.GetCustomAttribute(member, attribute.GetType());
            }
            catch (Exception ex)
            {
                LogException(ex);
                result = null;
            }

            return result;
        }

        public bool HasAttribute(Type type, Attribute attribute)
        {
            return GetAttribute(type, attribute) != null;
        }

        public bool HasAttribute(MemberInfo member, Attribute attribute)
        {
            return GetAttribute(member, attribute) != null;
        }

        public bool HasAnyAttribute(Type type, params Attribute[] attributes)
        {
            foreach (Attribute attribute in attributes)
            {
                if (HasAttribute(type, attribute))
                    return true;
            }

            return false;
        }

        public bool HasAnyAttribute(MemberInfo member, params Attribute[] attributes)
        {
            foreach (Attribute attribute in attributes)
            {
                if (HasAttribute(member, attribute))
                    return true;
            }

            return false;
        }

        private void LogException(Exception ex)
        {
            log.Exception(ex, "Exception in AttributeUtility");
        }
    }
}
