using BenchmarkDotNet.Attributes;
using SamuraiDojo.Attributes;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking.Benchmarks.IoC
{
    [MemoryDiagnoser]
    public class IoCBenchmarking
    {
        [Benchmark]
        public void Binding()
        {
            Factory.Bind<IBattleAttribute>(typeof(BattleAttribute));
            Factory.Bind<ISenseiAttribute>(typeof(SenseiAttribute));
            Factory.Bind<IWrittenByAttribute>(typeof(WrittenByAttribute));
            Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));
        }
    }
}
