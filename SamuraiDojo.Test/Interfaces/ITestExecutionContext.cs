using System;
using System.Reflection;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Test.Interfaces
{
    public interface ITestExecutionContext
    {
        Type ClassUnderTest { get; set; }
        MethodInfo Method { get; set; }
        Type TestClass { get; set; }
        IWrittenByAttribute WrittenBy { get; set; }
    }
}