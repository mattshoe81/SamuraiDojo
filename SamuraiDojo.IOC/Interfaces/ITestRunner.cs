using System;
using System.Reflection;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface ITestRunner
    {
        Action<ITestExecutionContext> OnTestFail { get; set; }
        Action<ITestExecutionContext> OnTestPass { get; set; }
        Action<ITestExecutionContext> PreTest { get; set; }

        ITestExecutionContext BuildTestExecutionContext(Type type, MethodInfo method);
        void Run();
        void Run(IWrittenByAttribute writtenBy, IBattleAttribute battle);
        int RunTests(Type type);
        int RunTests(Type type, MethodInfo[] tests, bool useCallbacks = true);
    }
}