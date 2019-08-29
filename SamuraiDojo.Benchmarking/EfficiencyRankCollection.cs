using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyRankCollection
    {
        private Dictionary<int, List<BattleStatsForPlayer>> efficiencyBuckets;

        public EfficiencyRankCollection()
        {
            efficiencyBuckets = new Dictionary<int, List<BattleStatsForPlayer>>();
        }

        public void Add(int rank, BattleStatsForPlayer battleResult)
        {
            if (efficiencyBuckets.ContainsKey(rank))
                efficiencyBuckets[rank].Add(battleResult);
            else
                efficiencyBuckets.Add(rank, new List<BattleStatsForPlayer> { battleResult });
        }

        public void Add(int rank, IEnumerable<BattleStatsForPlayer> battleResults)
        {
            foreach (BattleStatsForPlayer result in battleResults)
                Add(rank, result);
        }

        public List<BattleStatsForPlayer> Get(int rank)
        {
            List<BattleStatsForPlayer> resultsForRank = new List<BattleStatsForPlayer>();
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
