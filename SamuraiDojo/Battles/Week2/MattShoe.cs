using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week2
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : CharacterCounter
    {
        public override int CountPossibleCharacters(string integers)
        {
            int permutations = 0;

            for (int i = 0; i < integers.Length; i++)
            {
                if (int.Parse(integers.Substring(i, 1)) > 0)
                {
                    permutations++;

                    if (i < integers.Length - 1 && int.Parse(integers.Substring(i, 2)) <= 26)
                        permutations++;
                }
            }

            return permutations;
        }
    }

}
