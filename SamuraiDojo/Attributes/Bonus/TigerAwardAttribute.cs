using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes.Bonus
{
    public class TigerAwardAttribute : BonusPointsAttribute
    {
        public override int Points { get; } = 2;

        public override string Name { get; } = "Tiger Award";

        public override string Description { get; } = "This award goes to the player who solves the week's problem with the fewest lines of code. (CodeGolf.com -> Golf -> Tiger Woods -> TigerAward)";
    }
}
