using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;

namespace SamuraiDojo.Benchmarking
{
    class BenchmarkingStartup : IProjectStartup
    {
        public void ProjectInit()
        {
            new DojoStartup().ProjectInit();
            Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));
        }
    }
}
