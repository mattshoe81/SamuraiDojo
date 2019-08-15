using System;
using BenchmarkDotNet.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class BenchmarkInvoker
    {
        public static Action Action { get; set; }

        [Benchmark]
        public int Run()
        {
            try
            {
                Action();
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

            return 0;
        }
    }
}