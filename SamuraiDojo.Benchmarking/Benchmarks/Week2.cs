using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week2 : DojoBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Matt()
        {
            Run(new Test.Week2.Matt());
        }

        [Benchmark]
        public void Aaron()
        {
            Run(new Test.Week2.AaronTests());
        }

        [Benchmark]
        public void Dustin()
        {
            Run(new Test.Week2.Dustin());
        }
    }
}
