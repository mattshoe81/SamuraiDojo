using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.IoC.Interfaces;

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
