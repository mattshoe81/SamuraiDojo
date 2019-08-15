using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;
using SamuraiDojo.Test;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class BenchmarkEngine
    {
        public static List<BattleResult> PerformBenchmarking(BattleAttribute battle)
        {
            Type[] battleSolutions =
                ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test")?
                .Where(type => AttributeUtility.GetAttribute<UnderTestAttribute>(type).Type.FullName == battle.Type.FullName)?.ToArray();

            List<BattleResult> battleResults = new List<BattleResult>();
            foreach (Type type in battleSolutions)
            {
                EfficiencyResult efficiencyResult = CalculateAlgorithmEfficiency(type);

                WrittenByAttribute writtenBy = AttributeUtility.GetAttribute<WrittenByAttribute>(type);
                BattleResult battleResult = new BattleResult
                {
                    Efficiency = efficiencyResult,
                    Player = writtenBy
                };

                battleResults.Add(battleResult);
                Console.WriteLine($"Completed Benchmarking for {battleResult.Player.Name}");
            }

            return battleResults;
        }

        private static EfficiencyResult CalculateAlgorithmEfficiency(Type type)
        {
            Summary summary = RunBenchmarking(type);
            double efficiency = GetAverageExecutionTime(summary);
            double standardDeviation = GetStandardDeviation(summary);

            EfficiencyResult result = new EfficiencyResult
            {
                AverageExecutionTime = efficiency,
                StandardDeviation = standardDeviation
            };

            return result;
        }

        private static Summary RunBenchmarking(Type type)
        {
            IConfig config = DefaultConfig.Instance.With(ConfigOptions.DisableOptimizationsValidator);
            TestRunner testRunner = new TestRunner();
            BenchmarkInvoker.Action = () =>
            {
                testRunner.RunTests(type);
            };
#if DEBUG
            Summary summary = BenchmarkRunner.Run<BenchmarkInvoker>(config);
#endif
#if !DEBUG
            Summary summary = BenchmarkRunner.Run<BenchmarkInvoker>();
#endif
            if (summary.ValidationErrors != null && summary.ValidationErrors.Length > 0)
            {
                foreach (ValidationError error in summary.ValidationErrors)
                    Log.Error($"Benchmarking Validation Error: {Environment.NewLine}\t{error.Message}");
            }
            else
                Log.Info($"No Validation Errors encountered.");

            return summary;
        }

        private static double GetAverageExecutionTime(Summary summary)
        {
            double meanEfficiency = 0;
            try
            {
                BenchmarkCase benchmark = summary.BenchmarksCases[0];
                IColumn meanColumn = summary.GetColumns().Where(column => column.ColumnName.ToUpper() == "MEAN").FirstOrDefault();
                string meanString = meanColumn.GetValue(summary, benchmark, new SummaryStyle(true, SizeUnit.B, TimeUnit.Nanosecond, false));
                Log.Info("Mean String: " + meanString);
                meanEfficiency = double.Parse(meanString.Replace(",", ""));
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                meanEfficiency = 0;
            }

            return meanEfficiency;
        }

        private static double GetStandardDeviation(Summary summary)
        {
            double standardDeviation = 0;
            try
            {
                BenchmarkCase benchmark = summary.BenchmarksCases[0];
                IColumn meanColumn = summary.GetColumns().Where(column => column.ColumnName.ToUpper() == "STDDEV").FirstOrDefault();
                string stdDevString = meanColumn.GetValue(summary, benchmark, new SummaryStyle(true, SizeUnit.B, TimeUnit.Nanosecond, false));
                Log.Info("Standard Deviation String: " + stdDevString);
                standardDeviation = double.Parse(stdDevString.Replace(",", ""));
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                standardDeviation = 0;
            }

            return standardDeviation;
        }
    }
}
