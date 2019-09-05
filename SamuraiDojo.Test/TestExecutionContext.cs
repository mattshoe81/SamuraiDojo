using System;
using System.Reflection;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Interfaces;

namespace SamuraiDojo.Test
{
    internal class TestExecutionContext : ITestExecutionContext
    {
        public Type TestClass { get; set; }

        public Type ClassUnderTest { get; set; }

        public MethodInfo Method { get; set; }

        public IWrittenByAttribute WrittenBy { get; set; }
    }
}
