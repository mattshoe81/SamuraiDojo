using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week#;

namespace SamuraiDojo.Benchmarking.Benchmarks
{

    [MemoryDiagnoser]
    public class Week# : DojoBenchmark<SamuaraiDojo.Battles.Week#.YOUR_BATTLE_TYPE>
    {
        [Benchmark(Baseline = true)]
        public void Sensei()
        {
            Run(new Test.Week#.YourTestClass());
        }

        [Benchmark]
        public void PasteThisForEachPersonWhoParticipatedAndNameIfAfterThem()
        {
            Run(new Test.Week#.PersonTestClass());
        }
    }
}
