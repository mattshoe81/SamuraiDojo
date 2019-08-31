using System.Collections.Generic;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface IEfficiencyRankCollection
    {
        void Add(int rank, IPlayerBattleResult battleResult);
        void Add(int rank, IEnumerable<IPlayerBattleResult> battleResults);
        List<IPlayerBattleResult> Get(int rank);
        bool HasRank(int rank);
        int RankCount();
    }
}