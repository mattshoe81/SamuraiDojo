using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.SamuraiStats
{
    public class Score
    {
        public int SenseiCount { get; set; }

        public int TotalPoints { get; set; }

        public Dictionary<Type, int> PointsByChallenge { get; set; }
    }
}
