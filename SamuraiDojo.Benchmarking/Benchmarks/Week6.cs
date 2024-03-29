﻿using BenchmarkDotNet.Attributes;
using SamuraiDojo.Battles.Week6;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week6 : DojoBenchmark<SuperfluousSansLoop>
    {
        [Benchmark(Baseline = true)]
        public void MattShoe()
        {
            Run(new Test.Week6.MattShoe());
        }

        [Benchmark]
        public void Hugo()
        {
            Run(new Test.Week6.Hugo());
        }

        [Benchmark]
        public void JZ()
        {
            Run(new Test.Week6.JZ());
        }

        [Benchmark]
        public void JT()
        {
            Run(new Test.Week6.JT());
        }
    }
}
