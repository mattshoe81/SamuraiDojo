using System.Collections.Generic;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IEfficiencyCalculator
    {
        double Margin { get; }
        double MarginScalar { get; set; }

        IEfficiencyRankCollection RankBattleResults(List<IPlayerBattleResult> battleResults);
    }
}