using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Columns;
#if DEBUG
using BenchmarkDotNet.Configs;
#endif
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SamuraiDojo.Battles.Week1;
using SamuraiDojo.Battles.Week2;
using SamuraiDojo.Battles.Week3;
using SamuraiDojo.Battles.Week4;
using SamuraiDojo.Battles.Week5;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    internal class BenchmarkEngine : IBenchmarkEngine
    {
        private Dictionary<Type, Type> benchmarkMap;

        public BenchmarkEngine()
        {
            benchmarkMap = new Dictionary<Type, Type>
            {
                { typeof(CensusMaximus), typeof(Benchmarks.Week3) },
                { typeof(CharacterCounter), typeof(Benchmarks.Week2) },
                { typeof(ClockAngler), typeof(Benchmarks.Week1) },
                { typeof(Palindromania), typeof(Benchmarks.Week4) },
                { typeof(Snowflake), typeof(Benchmarks.Week5) } 
            };
        }

        public void PerformBenchmarking(Type type)
        {
            StartBenchmarking(type);
        }

        public List<IPlayerBattleResult> PerformBenchmarking(IBattleAttribute battle)
        {
            Summary summary = StartBenchmarking(benchmarkMap[battle.Type]);
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
            result.Player.Name = result.Player.Name.Replace("DEFAULTJOB", "");

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
