using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week4;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week4 : DojoBenchmark<Palindromania>
    {
        [Benchmark(Baseline = true)]
        public void Matt()
        {
            Run(new Test.Week4.MattShoe());
        }

        [Benchmark]
        public void Drew()
        {
            Run(new Test.Week4.DrewArdner());
        }

        [Benchmark]
        public void Dustin()
        {
            Run(new Test.Week4.Dustin());
        }

        [Benchmark]
        public void JT()
        {
            Run(new Test.Week4.JT());
        }
    }
}
