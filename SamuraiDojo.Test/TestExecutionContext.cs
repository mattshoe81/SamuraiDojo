using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Test
{
    public class TestExecutionContext
    {
        public Type TestClass { get; set; }

        public Type ClassUnderTest { get; set; }

        public MethodInfo Method { get; set; }

        public string WrittenBy { get; set; }  
    }
}
