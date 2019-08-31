﻿using System.Collections.Generic;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IBenchmarkEngine
    {
        List<IPlayerBattleResult> PerformBenchmarking(IBattleAttribute battle);
    }
}