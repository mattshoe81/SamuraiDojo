using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.Interfaces;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    internal class EfficiencyRankCollection : IEfficiencyRankCollection
    {
        private Dictionary<int, List<IPlayerBattleResult>> efficiencyBuckets;

        public EfficiencyRankCollection()
        {
            efficiencyBuckets = new Dictionary<int, List<IPlayerBattleResult>>();
        }

        public void Add(int rank, IPlayerBattleResult battleResult)
        {
            if (efficiencyBuckets.ContainsKey(rank))
                efficiencyBuckets[rank].Add(battleResult);
            else
                efficiencyBuckets.Add(rank, new List<IPlayerBattleResult> { battleResult });
        }

        public void Add(int rank, IEnumerable<IPlayerBattleResult> battleResults)
        {
            foreach (IPlayerBattleResult result in battleResults)
                Add(rank, result);
        }

        public List<IPlayerBattleResult> Get(int rank)
        {
            List<IPlayerBattleResult> resultsForRank = new List<IPlayerBattleResult>();
            if (efficiencyBuckets.ContainsKey(rank))
                resultsForRank = efficiencyBuckets[rank];

            resultsForRank.OrderBy(player => player.Efficiency.MemoryAllocated).GroupBy(player => player.Efficiency.AverageExecutionTime);

            return resultsForRank;
        }

        public bool HasRank(int rank)
        {
            return efficiencyBuckets.ContainsKey(rank);
        }

        public int RankCount()
        {
            return efficiencyBuckets.Keys.Count;
        }
    }
}
