using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Models;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyCalculator
    {
        public double MarginScalar { get; set; } = 1.0;

        public int Margin { get; private set; }

        private double minStdDev;

        public EfficiencyRankCollection RankBattleResults(List<BattleResult> battleResults)
        {
            EfficiencyRankCollection efficiencyRankCollection = new EfficiencyRankCollection();
            minStdDev = battleResults.Min(result => result.Efficiency.StandardDeviation);
            int rank = 1;
            while (battleResults.Count > 0)
            {
                BattleResult nextMostEfficient = battleResults[0];
                double margin = CalculateMargin(nextMostEfficient);
                double baseline = nextMostEfficient.Efficiency.AverageExecutionTime;

                BattleResult[] resultsWithSimilarEfficiency =
                    battleResults
                    .Where(result => IsWithinMargin(result, baseline))
                    .OrderBy(result => result.Efficiency.AverageExecutionTime).ToArray();

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
            bool result = Math.Abs(difference) < Margin;

            return result;
        }
    }
}
