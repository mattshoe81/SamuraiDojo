using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));

            HasBeenInitialized = true;
        }
    }
}
