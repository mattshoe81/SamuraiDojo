namespace SamuraiDojo.IoC.Interfaces
{
    public interface IEfficiencyResult
    {
        double AverageExecutionTime { get; set; }
        long MemoryAllocated { get; set; }
        double StandardDeviation { get; set; }
    }
}