using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking
{
    public class Setup : ProjectSetup
    {
        protected override bool HasBeenInitialized { get; set; }

        protected override void Initialize()
        {
            new SamuraiDojo.Setup();

            Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));

            HasBeenInitialized = true;
        }
    }
}
