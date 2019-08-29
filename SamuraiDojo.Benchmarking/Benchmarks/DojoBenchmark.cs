using System.Threading;
using SamuraiDojo.Test;

namespace SamuraiDojo.Benchmarking.Benchmarks
{
    /// <summary>
    /// Base class for all benchmarking classes. Simply pass an 
    /// instance of the player's test class to the run method
    /// defined in this class for benchmarking.
    /// </summary>
    public abstract class DojoBenchmark<T>
    {
        /// <summary>
        /// Given an instance of a player's test class, will
        /// call that test's Benchmark() method, safely 
        /// catching any exceptions. If an exception occurs,
        /// meaning the player failed the test case, then they
        /// will be penalized 250ms.
        /// </summary>
        /// <param name="test"></param>
        protected void Run(DojoTest<T> test)
        {
            try
            {
                test.Benchmark();
            }
            catch
            {
                Thread.Sleep(250);
            }
        }
    }
}
