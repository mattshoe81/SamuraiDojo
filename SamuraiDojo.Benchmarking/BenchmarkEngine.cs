using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week1;
using SamuraiDojo.Battles.Week2;
using SamuraiDojo.Battles.Week3;
using SamuraiDojo.Models;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class BenchmarkEngine
    {
        private static Dictionary<Type, Type> benchmarkMap;

        static BenchmarkEngine()
        {
            benchmarkMap = new Dictionary<Type, Type>
            {
                { typeof(CensusMaximus), typeof(Benchmarks.Week3) },
                { typeof(CharacterCounter), typeof(Benchmarks.Week2) },
                { typeof(ClockAngler), typeof(Benchmarks.Week1) }
            };
        }

        public static List<BattleResult> PerformBenchmarking(BattleAttribute battle)
        {
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(new string[0], new DebugInProcessConfig());
#endif
            Summary summary = BenchmarkRunner.Run(benchmarkMap[battle.Type]);
            List<BattleResult> battleResults = new List<BattleResult>();
            foreach (BenchmarkCase benchmark in summary.BenchmarksCases)
                battleResults.Add(ProcessCase(benchmark, summary));

            battleResults.OrderBy(result => result.Efficiency.AverageExecutionTime);

            return battleResults;
        }

        public static BattleResult ProcessCase(BenchmarkCase benchmark, Summary summary)
        {
            BattleResult result = new BattleResult();
            result.Player = new WrittenByAttribute(benchmark.DisplayInfo);
            result.Player.Name = result.Player.Name.Replace("DEFAULTJOB", "");

            double executionTime = GetAverageExecutionTime(benchmark, summary);
            double standardDeviation = GetStandardDeviation(benchmark, summary);
            long memoryAllocated = GetMemoryAllocated(benchmark, summary);

            result.Efficiency = new EfficiencyResult
            {
                AverageExecutionTime = executionTime,
                StandardDeviation = standardDeviation,
                MemoryAllocated = memoryAllocated
            };

            return result;
        }

        private static double GetAverageExecutionTime(BenchmarkCase benchmark, Summary summary)
        {
            double exeutionTime = GetValue<double>("MEAN", benchmark, summary);
            return exeutionTime;
        }

        private static double GetStandardDeviation(BenchmarkCase benchmark, Summary summary)
        {
            double standardDeviation = GetValue<double>("STDDEV", benchmark, summary);
            return standardDeviation;
        }

        private static long GetMemoryAllocated(BenchmarkCase benchmark, Summary summary)
        {
            long memory = GetValue<long>("ALLOCATED", benchmark, summary);
            return memory;
        }

        private static T GetValue<T>(string columnName, BenchmarkCase benchmark, Summary summary) where T : IConvertible
        {
            T value = default;
            try
            {
                IColumn meanColumn = summary.GetColumns().Where(column => column.ColumnName.EqualsIgnoreCase(columnName)).FirstOrDefault();
                string valueString = meanColumn.GetValue(summary, benchmark, new SummaryStyle(true, SizeUnit.B, TimeUnit.Nanosecond, false));
                Console.WriteLine($"Raw value for {columnName}: {valueString}");
                value = (T)Convert.ChangeType(valueString.Replace(",", ""), typeof(T));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                value = default;
            }

            return value;
        }
    }
}
