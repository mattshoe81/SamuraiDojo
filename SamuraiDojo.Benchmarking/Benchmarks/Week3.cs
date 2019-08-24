using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week3;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week3 : DojoBenchmark<CensusMaximus>
    {
        [Benchmark(Baseline = true)]
        public void Matt()
        {
            Run(new Test.Week3.MattShoe());
        }

        [Benchmark]
        public void Dustin()
        {
            Run(new Test.Week3.Dustin());
        }

        [Benchmark]
        public void Aaron()
        {
            Run(new Test.Week3.AaronTests());
        }
    }
}

