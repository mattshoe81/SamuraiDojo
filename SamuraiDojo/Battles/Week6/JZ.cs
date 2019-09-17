using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;

namespace SamuraiDojo.Battles.Week6
{
    [InceptorAward]
    [WrittenBy(Samurai.JEREMY_ZIMMERMAN)]
    public class JZ : SuperfluousSansLoop
    {
        public override string Print1toNWithoutLoops(int n)
        {
            if (n == 0)
                return n.ToString();
            else
                return Print1toNWithoutLoops(n - 1) + ", " + n.ToString();
        }
    }
}
