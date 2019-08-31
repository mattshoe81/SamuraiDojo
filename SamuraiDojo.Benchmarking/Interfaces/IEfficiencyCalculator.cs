using System.Collections.Generic;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking.Interfaces
{
    public interface IEfficiencyCalculator
    {
        double Margin { get; }
        double MarginScalar { get; set; }

        IEfficiencyRankCollection RankBattleResults(List<PlayerBattleResult> battleResults);
    }
}