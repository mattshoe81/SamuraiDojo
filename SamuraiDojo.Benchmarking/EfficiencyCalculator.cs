using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyCalculator
    {
        public const int DEFAULT_EFFICIENCY_ITERATIONS = 100;

        /// <summary>
        /// Given a test class, will execute all tests in that class repeatedly to obtain
        /// an average of the time it takes to execute all tests. The returned value is 
        /// the average number of ticks elapsed while executing the tests per iteration.
        /// One tick represent 100 nanoseconds
        /// </summary>
        /// <param name="testClass"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public double AnalyzeTests(Type testClass, int iterations = DEFAULT_EFFICIENCY_ITERATIONS)
        {
            long[] scores = new long[iterations];
            MethodInfo[] tests = ReflectionUtility.GetMethodsWithAttribute<BenchmarkAttribute>(testClass).ToArray();

            for (int i = 0; i < iterations; i++)
            {
                TestRunner testRunner = new TestRunner();
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                testRunner.RunTests(testClass, tests, false);
                stopwatch.Stop();

                long ticks = stopwatch.ElapsedTicks;
                scores[i] = ticks;
            }

            double efficiency = scores.Average();

            return efficiency;
        }
    }
}
