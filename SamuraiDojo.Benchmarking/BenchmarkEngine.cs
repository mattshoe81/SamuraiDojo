using System;
using System.Collections.Generic;
using System.Linq;
#if DEBUG
using BenchmarkDotNet.Configs;
#endif
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SamuraiDojo.Battles.Week1;
using SamuraiDojo.Battles.Week2;
using SamuraiDojo.Battles.Week3;
using SamuraiDojo.Battles.Week4;
using SamuraiDojo.Battles.Week5;
using SamuraiDojo.IoC;
using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.Utility;
using SamuraiDojo.Interfaces;
using SamuraiDojo.Battles.Week6;
using SamuraiDojo.Battles.Week7;

namespace SamuraiDojo.Benchmarking
{
    internal class BenchmarkEngine : IBenchmarkEngine
    {
        private Dictionary<string, Type> benchmarkMap;

        public BenchmarkEngine()
        {
            benchmarkMap = new Dictionary<string, Type>
            {
                { typeof(CensusMaximus).Name, typeof(Benchmarks.Week3) },
                { typeof(CharacterCounter).Name, typeof(Benchmarks.Week2) },
                { typeof(ClockAngler).Name, typeof(Benchmarks.Week1) },
                { typeof(Palindromania).Name, typeof(Benchmarks.Week4) },
                { typeof(Snowflake).Name, typeof(Benchmarks.Week5) } ,
                { typeof(SuperfluousSansLoop).Name, typeof(Benchmarks.Week6) },
                { typeof(SinglyLinkedList_Part1<int>).Name, typeof(Benchmarks.Week7) }
            };
        }

        public void PerformBenchmarking(Type type)
        {
            StartBenchmarking(type);
        }

        public List<IPlayerBattleResult> PerformBenchmarking(IBattleAttribute battle)
        {
            Summary summary = StartBenchmarking(benchmarkMap[battle.Type.Name]);
            List<IPlayerBattleResult> battleResults = new List<IPlayerBattleResult>();
            foreach (BenchmarkCase benchmark in summary.BenchmarksCases)
                battleResults.Add(ProcessCase(benchmark, summary));

            battleResults.OrderBy(result => result.Efficiency.AverageExecutionTime);

            return battleResults;
        }

        private Summary StartBenchmarking(Type type)
        {
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(new string[0], new DebugInProcessConfig());
#endif
            Summary summary = BenchmarkRunner.Run(type);

            return summary;
        }

        private IPlayerBattleResult ProcessCase(BenchmarkCase benchmark, Summary summary)
        {
            IPlayerBattleResult result = Factory.Get<IPlayerBattleResult>();
            result.Player = Factory.Get<IWrittenByAttribute>();
            result.Player.Name = benchmark.DisplayInfo;
            result.Player.Name = result.Player.Name.Replace("DefaultJob", "");

            double executionTime = GetAverageExecutionTime(benchmark, summary);
            double standardDeviation = GetStandardDeviation(benchmark, summary);
            long memoryAllocated = GetMemoryAllocated(benchmark, summary);

            result.Efficiency = Factory.Get<IEfficiencyResult>();
            result.Efficiency.AverageExecutionTime = executionTime;
            result.Efficiency.StandardDeviation = standardDeviation;
            result.Efficiency.MemoryAllocated = memoryAllocated;

            return result;
        }

        private double GetAverageExecutionTime(BenchmarkCase benchmark, Summary summary)
        {
            double exeutionTime = GetValue<double>("MEAN", benchmark, summary);
            return exeutionTime;
        }

        private double GetStandardDeviation(BenchmarkCase benchmark, Summary summary)
        {
            double standardDeviation = GetValue<double>("STDDEV", benchmark, summary);
            return standardDeviation;
        }

        private long GetMemoryAllocated(BenchmarkCase benchmark, Summary summary)
        {
            long memory = GetValue<long>("ALLOCATED", benchmark, summary);
            return memory;
        }

        private T GetValue<T>(string columnName, BenchmarkCase benchmark, Summary summary) where T : IConvertible
        {
            T value = default;
            try
            {
                IColumn meanColumn = summary.GetColumns().Where(column => column.ColumnName.EqualsIgnoreCase(columnName)).FirstOrDefault();
                string valueString = meanColumn.GetValue(summary, benchmark, new SummaryStyle(true, Program.SizeUnit, Program.TimeUnit, false));
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
