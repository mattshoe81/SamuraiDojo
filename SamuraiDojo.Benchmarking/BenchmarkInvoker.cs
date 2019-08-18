using System;
using BenchmarkDotNet.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    [MemoryDiagnoser]
    public class BenchmarkInvoker
    {
        public static Func<int> Action { get; set; }

        [Benchmark]
        public int Run()
        {
            int result = 0;
            try
            {
                if (Action == null)
                {
                    for (int i = 0; i < 100; i++)
                        Console.WriteLine("Action is not defined!!!!!!!!!!");
                }
                result = Action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            return result;
        }
    }
}