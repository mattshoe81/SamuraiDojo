using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test
{
    public class TestRunner
    {
        public Action<TestExecutionContext> OnTestPass { get; set; }
        public Action<TestExecutionContext> OnTestFail { get; set; }

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
            SolutionByAttribute solutionBy = GetAttribute<SolutionByAttribute>(type);
            UnderTestAttribute classUnderTest = GetAttribute<UnderTestAttribute>(type);
            TestExecutionContext testExecutionContext = new TestExecutionContext
            {
                TestClass = type,
                ClassUnderTest = classUnderTest?.Type,
                Method = method,
                WrittenBy = solutionBy?.Name
            };

            try
            {
                object instance = Activator.CreateInstance(type);
                method.Invoke(instance, null);

                OnTestPass?.Invoke(testExecutionContext);
            }
            catch
            {
                OnTestFail?.Invoke(testExecutionContext);
            }
        }

        private bool HasAttribute<T>(Type type)
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

        private bool HasAttribute<T>(MemberInfo member)
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

        private T GetAttribute<T>(Type type) where T : Attribute
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
