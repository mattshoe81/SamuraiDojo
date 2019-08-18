﻿using BenchmarkDotNet.Attributes;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    [MemoryDiagnoser]
    public class Week3 : DojoBenchmark
    {
        [Benchmark]
        public void Matt()
        {
            Run(new Test.Week3.Matt());
        }
    }
}

