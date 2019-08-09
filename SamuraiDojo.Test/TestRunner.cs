using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test
{
    public class TestRunner
    {
        public void Run()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (HasAttribute<SolutionByAttribute>(type))
                {
                    MethodInfo[] methods = type.GetMethods();
                    foreach (MethodInfo method in methods)
                    {
                        if (HasAttribute<TestMethodAttribute>(method))
                            EvaluteTest(type, method);
                    }
                }
            }
        }

        public void EvaluteTest(Type type, MethodInfo method)
        {
            try
            {
                object instance = Activator.CreateInstance(type);
                method.Invoke(instance, null);

                SolutionByAttribute solutionBy = (SolutionByAttribute)Attribute.GetCustomAttribute(type, typeof(SolutionByAttribute));
                UnderTestAttribute underTest = (UnderTestAttribute)Attribute.GetCustomAttribute(type, typeof(UnderTestAttribute));
                Samurai.AddPoint(solutionBy.Name, underTest.Type);
            }
            catch { }
        }

        private bool HasAttribute<T>(Type type)
        {
            bool result = false;
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

        private bool HasAttribute<T>(MemberInfo member)
        {
            bool result = false;
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
    }
}
