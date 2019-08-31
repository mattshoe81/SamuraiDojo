using System.Collections.Generic;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking.Interfaces
{
    public interface IEfficiencyRankCollection
    {
        void Add(int rank, PlayerBattleResult battleResult);
        void Add(int rank, IEnumerable<PlayerBattleResult> battleResults);
        List<PlayerBattleResult> Get(int rank);
        bool HasRank(int rank);
        int RankCount();
    }
}