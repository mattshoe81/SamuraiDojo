using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes.Bonus
{
    public class MostEfficientAttribute : BonusPointsAttribute
    {
        public override int Points { get; } = 4;

        public override string Name { get; } = "Most Efficient";
    }
}
