using SamuraiDojo.Attributes;
using System.Linq;
using System;

namespace SamuraiDojo.Battles.Week4
{
    [WrittenBy(Samurai.JT)]
    public class JT : Palindromania
    {
        public override string LargestPalindrome(string input)
        {
            input = input.ToLower();
            string largestPalindrome = input[0].ToString();
            int palStartIndex = 0;
            string reversedInput = String.Join("", input.Reverse());

            for (int i = 1; i < input.Length; i++)
            {
                string substr = input.Substring(palStartIndex, largestPalindrome.Length + 1);
                if (reversedInput.Contains(substr))
                {
                    largestPalindrome = substr;
                }
                else
                {
                    palStartIndex++;
                    if (input.Length - palStartIndex < largestPalindrome.Length) break;
                }
            }
            return largestPalindrome;
        }
    }
}
