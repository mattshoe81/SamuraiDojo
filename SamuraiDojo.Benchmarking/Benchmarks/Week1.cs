using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week1 : DojoBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Matt()
        {
            Run(new Test.Week1.Matt());
        }

        [Benchmark]
        public void JT()
        {
            Run(new Test.Week1.JT());
        }

        [Benchmark]
        public void Jeff()
        {
            Run(new Test.Week1.Jeff());
        }

        [Benchmark]
        public void Dustin()
        {
            Run(new Test.Week1.Dustin());
        }
    }
}
