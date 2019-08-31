using System.Collections.Generic;

namespace SamuraiDojo.IOC.Interfaces
{
    public interface IEfficiencyCalculator
    {
        double Margin { get; }
        double MarginScalar { get; set; }

        IEfficiencyRankCollection RankBattleResults(List<IPlayerBattleResult> battleResults);
    }
}