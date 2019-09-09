using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week5;
using SamuraiDojo.Battles.Week6;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week6 : DojoBenchmark<SuperfluousSansLoop>
    {
        [Benchmark(Baseline = true)]
        public void MattShoe()
        {
            Run(new Test.Week6.MattShoe());
        }

        [Benchmark]
        public void Hugo()
        {
            Run(new Test.Week6.Hugo());
        }
    }
}
