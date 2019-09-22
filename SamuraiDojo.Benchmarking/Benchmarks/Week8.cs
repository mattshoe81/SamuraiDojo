using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week7;
using SamuraiDojo.Battles.Week8;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week8 : DojoBenchmark<SinglyLinkedList_Part2<int>>
    {
        [Benchmark(Baseline = true)]
        public void MattShoe() => Run(new Test.Week8.MattShoe());

        // Change method name and parameter to your stuff
        [Benchmark]
        public void YourName() => Run(new Test.Week8.MattShoe());
    }
}
