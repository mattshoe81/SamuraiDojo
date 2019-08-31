using System.Collections.Generic;

namespace SamuraiDojo.IOC.Interfaces
{
    public interface IBenchmarkEngine
    {
        List<IPlayerBattleResult> PerformBenchmarking(IBattleAttribute battle);
    }
}