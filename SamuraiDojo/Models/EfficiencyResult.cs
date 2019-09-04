using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Models
{
    internal class EfficiencyResult : IEfficiencyResult
    {
        public double AverageExecutionTime { get; set; }

        public double StandardDeviation { get; set; }

        public long MemoryAllocated { get; set; }
    }
}
