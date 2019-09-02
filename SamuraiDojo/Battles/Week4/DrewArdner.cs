using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiDojo.Battles.Week4
{
    [MostElegant]
    [WrittenBy(Samurai.Drew)]
    public class DrewArdner : Palindromania
    {
        public override string LargestPalindrome(string input)
        {
            string largestPalindrome = null;

            char[] inputArray = input.ToUpper().ToCharArray();

            //separate all potential strings from the base string; think large diamond shape
            List<string> palindromesToCheck = BreakApartPotentialPalindromes(inputArray);
            
            //container for all valid, checked palindromes
            List<string> validPalindromes = new List<string>();
            
            for (int i = 0; i < palindromesToCheck.Count; i++)
            {
                if (CheckIfStringIsValidPalindrome(palindromesToCheck[i]))
                {
                    validPalindromes.Add(palindromesToCheck[i]);
                }
            }

            //find longest palindrome in list
            largestPalindrome = validPalindromes.Count() != 0 ? validPalindromes.OrderByDescending(p => p.Length).FirstOrDefault().ToString() : "";

            return largestPalindrome;
        }

        private List<string> BreakApartPotentialPalindromes(char[] inputArray)
        {
            List<string> potentialPalindromes = new List<string>();
            string containerString = "";

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int k = i; k < inputArray.Length; k++)
                {
                    containerString += inputArray[k];
                    potentialPalindromes.Add(containerString);
                }
                containerString = "";
            }

            return potentialPalindromes;
        }

        private bool CheckIfStringIsValidPalindrome(string input)
        {
            bool IsValidPalindrome = false;

            char[] inputCharArray = input.ToUpper().ToCharArray();



            /*  check if character at i matches character at mirrored point in string;
             *  example correct:
             *      tacocat
             *      1234567
             *  
             *      compare 1 to 7; √
             *      compare 2 to 6; √
             *      ...
             *      
             *      if all are good, string is valid palindrome;
             *      
             *      ** only need to go thru half, since you're comparing both sides;
             *  
             *  example incorrect:
             *      tacocot
             *      1234567
             *      
             *      compare 1 to 7; √
             *      compare 2 to 6; X
             *      
             *      the moment no match found, break and move onto the next string, as this string isn't valid
             * 
             */

            for (int i = 0; i <= inputCharArray.Length / 2; i++)
            {
                if (inputCharArray[i] != inputCharArray[inputCharArray.Length - i - 1])
                {
                    IsValidPalindrome = false;
                    break;
                }
                IsValidPalindrome = true;
            }

            return IsValidPalindrome;
        }
    }
}
