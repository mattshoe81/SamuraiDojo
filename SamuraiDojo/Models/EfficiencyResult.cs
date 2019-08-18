using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Models
{
    public class EfficiencyResult
    {
        public double AverageExecutionTime { get; set; }

        public double StandardDeviation { get; set; }

        public long MemoryAllocated { get; set; }
    }
}
