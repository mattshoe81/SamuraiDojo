using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes.Bonus
{
    public class MostEfficientAttribute : BonusPointsAttribute
    {
        public override int Points { get; } = 6;

        public override string Name { get; } = "Most Efficient";

        public override string Description { get; } = "This award goes to the player whose algorithm takes the least amount of time to run. For details on how this is measured, see the benchmarking page.";
    }
}
