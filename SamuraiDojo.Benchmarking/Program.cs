using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using SamuraiDojo.Attributes;
using SamuraiDojo.Repositories;
using SamuraiDojo.Test;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            PerformBenchmarking();

            Console.WriteLine(stringBuilder.ToString());
        }

        private static void PerformBenchmarking()
        {
            Type[] battleSolutions = ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test");
            foreach (Type type in battleSolutions)
            {
                Summary summary = RunBenchmarking(type);
                double efficiency = GetEfficiencyScore(summary);

                UnderTestAttribute underTest = AttributeUtility.GetAttribute<UnderTestAttribute>(type);
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(underTest.Type);
                WrittenByAttribute writtenBy = AttributeUtility.GetAttribute<WrittenByAttribute>(type);
                BattleRepository.SetEfficiencyScore(battle, writtenBy, efficiency);
            }
        }

        private static Summary RunBenchmarking(Type type)
        {
            IConfig config = DefaultConfig.Instance.With(ConfigOptions.DisableOptimizationsValidator);
            TestRunner testRunner = new TestRunner();
            BattleBenchmarkRunner.Action = () =>
            {
                testRunner.RunTests(type);
            };
#if DEBUG
            Summary summary = BenchmarkRunner.Run<BattleBenchmarkRunner>(config);
#endif
#if !DEBUG
            Summary summary = BenchmarkRunner.Run<BattleBenchmarkRunner>();
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

        private static double GetEfficiencyScore(Summary summary)
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
    }
}
