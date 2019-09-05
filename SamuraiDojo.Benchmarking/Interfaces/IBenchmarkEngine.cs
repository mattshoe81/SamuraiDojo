using System;
using System.Collections.Generic;
using SamuraiDojo.Interfaces;

namespace SamuraiDojo.Benchmarking.Interfaces
{
    public interface IBenchmarkEngine
    {
        List<IPlayerBattleResult> PerformBenchmarking(IBattleAttribute battle);

        void PerformBenchmarking(Type type);
    }
}