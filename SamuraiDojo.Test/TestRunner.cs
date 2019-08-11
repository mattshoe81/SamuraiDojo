using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Test
{
    /// <summary>
    /// This class will execute all tests in this assembly. 
    /// You may provide an Action to be executed upon successful test,
    /// and you may provide an Action to be executed upon failed test.
    /// The context in which the test was executed will provided to each 
    /// action.
    /// 
    /// No Action is required for execution.
    /// </summary>
    public class TestRunner
    {
        public Action<TestExecutionContext> OnTestPass { get; set; }
        public Action<TestExecutionContext> OnTestFail { get; set; }

        public void Run()
        {
            Type[] types = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test");

            foreach (Type type in types)
            {
                List<MethodInfo> methods = ReflectionUtility.GetMethodsWithAttribute<TestMethodAttribute>(type);
                foreach (MethodInfo method in methods)
                    EvaluteTest(type, method);
            }
        }

        public void EvaluteTest(Type type, MethodInfo method)
        {
            WrittenByAttribute writtenBy = AttributeUtility.GetAttribute<WrittenByAttribute>(type);
            UnderTestAttribute classUnderTest = AttributeUtility.GetAttribute<UnderTestAttribute>(type);
            TestExecutionContext testExecutionContext = new TestExecutionContext
            {
                TestClass = type,
                ClassUnderTest = classUnderTest?.Type,
                Method = method,
                WrittenBy = writtenBy
            };

            try
            {
                object instance = Activator.CreateInstance(type);
                method.Invoke(instance, null);

                // No exception, so test was passed
                OnTestPass?.Invoke(testExecutionContext);
            }
            catch
            {
                OnTestFail?.Invoke(testExecutionContext);
            }
        }
    }
}
