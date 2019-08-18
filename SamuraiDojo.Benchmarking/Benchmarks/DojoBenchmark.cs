using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SamuraiDojo.Test;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    public abstract class DojoBenchmark 
    {
        protected void Run(DojoTest test)
        {
            try
            {
                test.Benchmark();
            } 
            catch (Exception ex)
            {
                Thread.Sleep(250);
            }
        }
    }
}
