using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Challenges.Week2
{
    [WrittenBy(Samurai.Aaron)]
    public class Aaron : ICharacterCounter
    {
        public int CountPossibleCharacters(string integers)
        {
            var validCharCount = 0;
            if(integers.Length == 0) { return 0; }
            const int CharmapShift = 64; //The first 64 characters in ASCII are non-alpha. A == 65.
            for (int i = 0; i < integers.Length; i++)
            {
                int single = int.Parse(integers.Substring(i, 1));
                if (single <= 0)
                {
                    continue;
                }
                var singleChar = (char)(single + CharmapShift);
                validCharCount++;

                if (i >= integers.Length - 1)
                {
                    continue;
                }
                int doub = int.Parse(integers.Substring(i, 2));
                var doubChar = (char)(doub + CharmapShift);
                if (0 < doub && doub <= 26) { validCharCount++; }
            }

            return validCharCount;
        }
    }
}
