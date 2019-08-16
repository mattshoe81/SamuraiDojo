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
    }
}
