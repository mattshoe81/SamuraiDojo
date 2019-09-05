using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Test.Interfaces;
using SamuraiDojo.Utility.Interfaces;

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
    internal class TestRunner : ITestRunner
    {
        public Action<ITestExecutionContext> PreTest { get; set; }
        public Action<ITestExecutionContext> OnTestPass { get; set; }
        public Action<ITestExecutionContext> OnTestFail { get; set; }

        private IReflectionUtility reflectionUtility;
        private IAttributeUtility attributeUtility;
        private ILog log;

        public TestRunner(IReflectionUtility reflectionUtility, IAttributeUtility attributeUtility, ILog log)
        {
            this.reflectionUtility = reflectionUtility;
            this.attributeUtility = attributeUtility;
            this.log = log;
        }

        public void Run()
        {
            Type[] types = reflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test");

            foreach (Type type in types)
                RunTests(type);
        }

        public void Run(IWrittenByAttribute writtenBy, IBattleAttribute battle)
        {
            Type[] allBattleTests = reflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test")
                .Where(test => attributeUtility.GetAttribute<WrittenByAttribute>(test) == writtenBy)?.ToArray();

            Type battleTest = allBattleTests
                .Where(testClass => attributeUtility.GetAttribute<UnderTestAttribute>(testClass).Type.FullName == battle.Type.FullName).FirstOrDefault();

            RunTests(battleTest);
        }

        public int RunTests(Type type)
        {
            List<MethodInfo> methods = reflectionUtility.GetMethodsWithAttribute<TestMethodAttribute>(type);
            int passed = 0;
            foreach (MethodInfo method in methods)
                passed += EvaluteTest(type, method) ? 1 : 0;

            return passed;
        }

        public int RunTests(Type type, MethodInfo[] tests, bool useCallbacks = true)
        {
            int passed = 0;
            foreach (MethodInfo method in tests)
                passed += EvaluteTest(type, method, false) ? 1 : 0;

            return passed;
        }

        private bool EvaluteTest(Type type, MethodInfo method, bool useCallbacks = true)
        {
            ITestExecutionContext testExecutionContext = null;
            if (useCallbacks)
                testExecutionContext = BuildTestExecutionContext(type, method);
            bool passed = false;
            try
            {
                InvokeAction(PreTest, testExecutionContext);
                object instance = Activator.CreateInstance(type);
                method.Invoke(instance, null);

                passed = true;
                InvokeAction(OnTestPass, testExecutionContext);
            }
            catch (Exception ex)
            {
                log.Warning($"Failed Test: {ex?.InnerException?.Message}");
                InvokeAction(OnTestFail, testExecutionContext);
            }

            return passed;
        }

        public ITestExecutionContext BuildTestExecutionContext(Type type, MethodInfo method)
        {
            IWrittenByAttribute writtenBy = attributeUtility.GetAttribute<WrittenByAttribute>(type);
            IUnderTestAttribute classUnderTest = attributeUtility.GetAttribute<UnderTestAttribute>(type);
            ITestExecutionContext testExecutionContext = Factory.Get<ITestExecutionContext>();
            testExecutionContext.TestClass = type;
            testExecutionContext.ClassUnderTest = classUnderTest?.Type;
            testExecutionContext.Method = method;
            testExecutionContext.WrittenBy = writtenBy;

            return testExecutionContext;
        }

        private void InvokeAction(Action<ITestExecutionContext> action, ITestExecutionContext testExecutionContext)
        {
            try
            {
                // No exception, so test was passed
                action?.Invoke(testExecutionContext);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
        }
    }
}
