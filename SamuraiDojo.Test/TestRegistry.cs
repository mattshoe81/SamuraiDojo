using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Test
{
    public class TestRegistry
    {
        public static readonly List<Type> Tests;

        static TestRegistry()
        {
            Tests = new List<Type>();
        }

        public static void Register(Type test)
        {
            Tests.Add(test);
        }
    }
}
