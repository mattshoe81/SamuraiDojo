using SamuraiDojo.IOC.Interfaces;

namespace SamuraiDojo.Models
{
    public class EfficiencyResult : IEfficiencyResult
    {
        public double AverageExecutionTime { get; set; }

        public double StandardDeviation { get; set; }

        public long MemoryAllocated { get; set; }
    }
}
