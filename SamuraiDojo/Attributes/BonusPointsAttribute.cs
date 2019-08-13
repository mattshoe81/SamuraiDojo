using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public abstract class BonusPointsAttribute : Attribute
    {
        public abstract int Points { get; }
    }
}
