using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week5;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week5 : DojoBenchmark<Snowflake>
    {
        [Benchmark(Baseline = true)]
        public void MattShoe()
        {
            Run(new Test.Week5.MattShoe());
        }

        [Benchmark]
        public void Dustin()
        {
            Run(new Test.Week5.Dustin());
        }
    }
}
