using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week7;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    public class Week7 : DojoBenchmark<SinglyLinkedList_Part1<int>>
    {
        [Benchmark(Baseline = true)]
        public void MattShoe()
        {
            Run(new Test.Week7.MattShoe());
        }
    }
}
