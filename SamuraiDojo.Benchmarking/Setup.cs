using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking
{
    public class Setup : ProjectSetup
    {
        private static bool initialized = false;

        protected override bool HasBeenInitialized => initialized;

        protected override void Initialize()
        {
            new SamuraiDojo.Setup();

            Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));

            initialized = true;
        }
    }
}
