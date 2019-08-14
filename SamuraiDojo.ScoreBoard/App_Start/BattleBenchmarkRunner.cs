using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BenchmarkDotNet.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.App_Start
{
    public class BattleBenchmarkRunner
    {
        public static Action Action { get; set; }

        [Benchmark]
        public int Run()
        {
            try
            {
                Action();
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }

            return 0;
        }
    }
}