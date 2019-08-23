using BenchmarkDotNet.Attributes;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week3 : DojoBenchmark
    {
        [Benchmark(Baseline = true)]
        public void Matt()
        {
            Run(new Test.Week3.Matt());
        }

        [Benchmark]
        public void Dustin()
        {
            Run(new Test.Week3.Dustin());
        }
    }
}

