using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking.Interfaces
{
    public interface IBenchmarkEngine
    {
        List<PlayerBattleResult> PerformBenchmarking(BattleAttribute battle);
    }
}