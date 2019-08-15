using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public Action<TestExecutionContext> PreTest { get; set; }
        public Action<TestExecutionContext> OnTestPass { get; set; }
        public Action<TestExecutionContext> OnTestFail { get; set; }

        public void Run()
        {
            Type[] types = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test");

            foreach (Type type in types)
                RunTests(type);
        }

        public void Run(WrittenByAttribute writtenBy, BattleAttribute battle)
        {
            Type[] allBattleTests = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test")
                .Where(test => AttributeUtility.GetAttribute<WrittenByAttribute>(test) == writtenBy)?.ToArray();

            Type battleTest = allBattleTests
                .Where(testClass => AttributeUtility.GetAttribute<UnderTestAttribute>(testClass).Type.FullName == battle.Type.FullName).FirstOrDefault();

            RunTests(battleTest);
        }

        public void RunTests(Type type)
        {
            List<MethodInfo> methods = ReflectionUtility.GetMethodsWithAttribute<TestMethodAttribute>(type);
            foreach (MethodInfo method in methods)
                EvaluteTest(type, method);
        }

        public void RunTests(Type type, MethodInfo[] tests, bool useCallbacks = true)
        {
            foreach (MethodInfo method in tests)
                EvaluteTest(type, method, false);
        }

        private void EvaluteTest(Type type, MethodInfo method, bool useCallbacks = true)
        {
            TestExecutionContext testExecutionContext = null;
            if (useCallbacks)
                testExecutionContext = BuildTestExecutionContext(type, method);

            try
            {
                InvokeAction(PreTest, testExecutionContext);
                object instance = Activator.CreateInstance(type);
                method.Invoke(instance, null);

                InvokeAction(OnTestPass, testExecutionContext);
            }
            catch (Exception ex)
            {
                Log.Warning($"Failed Test: {ex?.InnerException?.Message}");
                InvokeAction(OnTestFail, testExecutionContext);
            }
        }

        public TestExecutionContext BuildTestExecutionContext(Type type, MethodInfo method)
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

            return testExecutionContext;
        }

        private void InvokeAction(Action<TestExecutionContext> action, TestExecutionContext testExecutionContext)
        {
            try
            {
                // No exception, so test was passed
                action?.Invoke(testExecutionContext);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }
    }
}
