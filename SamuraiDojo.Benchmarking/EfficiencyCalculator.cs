using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyCalculator
    {
        public double MarginScalar { get; set; } = 1.5;

        public double Margin { get; private set; }

        private double minStdDev;

        public EfficiencyRankCollection RankBattleResults(List<BattleResult> battleResults)
        {
            EfficiencyRankCollection efficiencyRankCollection = new EfficiencyRankCollection();
            minStdDev = battleResults.Min(result => result.Efficiency.StandardDeviation);
            int rank = 1;

            battleResults = battleResults.OrderBy(result => result.Efficiency.AverageExecutionTime).ToList();
            while (battleResults.Count > 0)
            {
                BattleResult nextMostEfficient = battleResults[0];
                Margin = CalculateMargin(nextMostEfficient);
                double baseline = nextMostEfficient.Efficiency.AverageExecutionTime;

                BattleResult[] resultsWithSimilarEfficiency =
                    battleResults
                    .Where(result => IsWithinMargin(result, baseline))
                    .OrderBy(result => result.Efficiency.MemoryAllocated).ToArray();

                battleResults.RemoveAll(result => resultsWithSimilarEfficiency.Contains(result));

                efficiencyRankCollection.Add(rank, resultsWithSimilarEfficiency);
                rank++;
            }

            return efficiencyRankCollection;
        }

        private double CalculateMargin(BattleResult result)
        {
            return minStdDev * MarginScalar;
        }

        private bool IsWithinMargin(BattleResult battleResult, double baseline)
        {
            double difference = battleResult.Efficiency.AverageExecutionTime - baseline;
            bool result = Math.Abs(difference) <= Margin;

            return result;
        }
    }
}
