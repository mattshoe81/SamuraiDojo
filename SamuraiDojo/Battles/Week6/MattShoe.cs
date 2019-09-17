using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week6
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : SuperfluousSansLoop
    {
        public override string Print1toNWithoutLoops(int n)
        {
            // Use StringBuilder to improve memory efficiency
            return BuildStringRecursively(new StringBuilder(), n).ToString();
        }

        private StringBuilder BuildStringRecursively(StringBuilder stringBuilder, int n)
        {
            if (n == 0)
                stringBuilder.Append('0');
            else
            {
                BuildStringRecursively(stringBuilder, n - 1);
                stringBuilder.Append(new char[] { ',', ' ' });
                stringBuilder.Append(n.ToString());
            }

            return stringBuilder;
        }
    }
}
