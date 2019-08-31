using System;
using System.Reflection;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface ITestExecutionContext
    {
        Type ClassUnderTest { get; set; }
        MethodInfo Method { get; set; }
        Type TestClass { get; set; }
        IWrittenByAttribute WrittenBy { get; set; }
    }
}