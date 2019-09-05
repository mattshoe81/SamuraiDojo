using System.Reflection;
using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            Dojector.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Dojector.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Dojector.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));

            HasBeenInitialized = true;
        }
    }
}
