using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking
{
    public class Setup : IProjectSetup
    {
        private static bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                new SamuraiDojo.Setup().Initialize();
                Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
                Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
                Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));

                initialized = true;
            }
        }
    }
}
