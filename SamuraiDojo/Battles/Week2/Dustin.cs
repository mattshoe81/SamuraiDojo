using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;

namespace SamuraiDojo.Battles.Week2
{
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : CharacterCounter
    {
        public override int CountPossibleCharacters(string integers)
        {
            int permutations = 0;

            string checkDoubleDigit = "";
            string checkSingleDigit = "";
            bool addToPermutations = false;



            for (int i = 0; i < integers.Length; i++)
            {
                if (integers.Substring(i, 1) == "0")
                {

                }
                else if ((integers.Substring(i, 1) == "1" || integers.Substring(i, 1) == "2") && i != integers.Length - 1)
                {

                    checkSingleDigit = integers.Substring(i, 1);
                    addToPermutations = IsValidPermutation(checkSingleDigit);

                    if (addToPermutations)
                    {
                        permutations++;
                        addToPermutations = false;
                    }

                    checkDoubleDigit = integers.Substring(i, 2);
                    addToPermutations = IsValidPermutation(checkDoubleDigit);

                    if (addToPermutations)
                    {
                        permutations++;
                        addToPermutations = false;
                    }

                }
                else
                {
                    checkSingleDigit = integers.Substring(i, 1);
                    addToPermutations = IsValidPermutation(checkSingleDigit);

                    if (addToPermutations)
                    {
                        permutations++;
                        addToPermutations = false;
                    }
                }
            }


            return permutations;
        }


        public bool IsValidPermutation(string input)
        {
            bool successfulParse = false;
            int intSingleDigit = 0;

            successfulParse = Int32.TryParse(input, out intSingleDigit);

            if (successfulParse && intSingleDigit >= 1 && intSingleDigit <= 26)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}