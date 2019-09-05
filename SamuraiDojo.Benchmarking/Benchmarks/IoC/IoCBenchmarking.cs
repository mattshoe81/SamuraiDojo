using BenchmarkDotNet.Attributes;
using SamuraiDojo.Attributes;
using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.Interfaces;
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
            Dojector.Bind<IBattleAttribute>(typeof(BattleAttribute));
            Dojector.Bind<ISenseiAttribute>(typeof(SenseiAttribute));
            Dojector.Bind<IWrittenByAttribute>(typeof(WrittenByAttribute));
            Dojector.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Dojector.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Dojector.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));
        }
    }
}
