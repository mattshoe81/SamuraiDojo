using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes.Bonus
{
    public class MostElegantAttribute : BonusPointsAttribute
    {
        public override int Points { get; } = 4;

        public override string Name { get; } = "Most Elegant";

        public override string Description { get; } = "This award goes to the player whose algorithm solves the problem in an unusually clever or simplistic way. Entirely subjective and at the discretion of the sensei.";
    }
}
