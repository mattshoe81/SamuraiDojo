using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week4;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    public class Week4 : DojoBenchmark<Palindromania>
    {
        [Benchmark(Baseline = true)]
        public void Matt()
        {
            Run(new Test.Week4.MattShoe());
        }
    }
}
