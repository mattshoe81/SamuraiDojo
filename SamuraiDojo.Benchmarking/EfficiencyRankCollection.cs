using System.Collections.Generic;
using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyRankCollection : IEfficiencyRankCollection
    {
        private Dictionary<int, List<PlayerBattleResult>> efficiencyBuckets;

        public EfficiencyRankCollection()
        {
            efficiencyBuckets = new Dictionary<int, List<PlayerBattleResult>>();
        }

        public void Add(int rank, PlayerBattleResult battleResult)
        {
            if (efficiencyBuckets.ContainsKey(rank))
                efficiencyBuckets[rank].Add(battleResult);
            else
                efficiencyBuckets.Add(rank, new List<PlayerBattleResult> { battleResult });
        }

        public void Add(int rank, IEnumerable<PlayerBattleResult> battleResults)
        {
            foreach (PlayerBattleResult result in battleResults)
                Add(rank, result);
        }

        public List<PlayerBattleResult> Get(int rank)
        {
            List<PlayerBattleResult> resultsForRank = new List<PlayerBattleResult>();
            if (efficiencyBuckets.ContainsKey(rank))
                resultsForRank = efficiencyBuckets[rank];

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
