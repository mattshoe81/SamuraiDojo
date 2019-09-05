using System.Collections.Generic;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Benchmarking.Interfaces
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