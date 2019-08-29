using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week4
{
    [Sensei(Samurai.MATT_SHOE)]
    [Battle("8/30/19", "PalindroMania", typeof(Palindromania))]
    public abstract class Palindromania
    {
        /// <summary>
        /// A palindrome is just a string that is spelled the same forwards and backwards.
        /// Given an arbitrarily large string, find the largest palindrome within that 
        /// string.
        ///     
        /// HINT:
        ///     - Palindromes are symmetric about their center....
        ///     - Difference between even and odd lengths?....
        /// 
        /// Constraints:
        ///     1. The string is never null, and always has at least 1 character in it.
        ///     2. The characters can be ANY valid ASCII character.
        ///     2. Comparisons should be CASE-INSENSITIVE.
        ///     3. If there are multiples, pick the first.
        /// 
        /// </summary>
        /// <param name="input">An arbitrarily large string.</param>
        /// <returns>The largest palindrome within the input string</returns>
        public abstract string LargestPalindrome(string input);
    }
}
