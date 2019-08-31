using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes.Bonus
{

    public class InceptorAward : BonusPointsAttribute
    {
        public override int Points { get; } = 5;
        public override string Name { get; } = "Inceptor Award";
        public override string Description { get; } = "This award goes to the anyone who solves the week's puzzle recursively. (recursion -> methods within methods -> Inception -> Inceptor)";
    }
}
