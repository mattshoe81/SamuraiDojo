using System.Collections.Generic;
using SamuraiDojo.Interfaces;

namespace SamuraiDojo.Benchmarking.Interfaces
{
    public interface IEfficiencyCalculator
    {
        double Margin { get; }
        double MarginScalar { get; set; }

        IEfficiencyRankCollection RankBattleResults(List<IPlayerBattleResult> battleResults);
    }
}