using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Intefaces;

namespace SamuraiDojo.Benchmarking
{
    class BenchmarkingStartup : IProjectStartup
    {
        public void ProjectInit()
        {
            Factory.Bind<IEfficiencyCalculator>(typeof(EfficiencyCalculator));
            Factory.Bind<IEfficiencyRankCollection>(typeof(EfficiencyRankCollection));
            Factory.Bind<IBenchmarkEngine>(typeof(BenchmarkEngine));
        }
    }
}
