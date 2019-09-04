using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week5
{
    [Sensei(Samurai.MATT_SHOE)]
    [Battle("9/9/19", "Snowflake", typeof(Snowflake))]
    public abstract class Snowflake
    {
        /// <summary>
        /// Find the first unique character in the given string. Simple, right?
        /// 
        /// This puzzle is a piece of cake if you prefer brute force, but be careful because the brute 
        /// force method will land you in O(n^2) at best for your run time. With some clever use of data
        /// structures, there is indeed a way to find the result in linear [O(n)] time.
        /// 
        /// Hint:
        ///     = Is there a data structure that can be used to check duplicates in O(1) time?
        /// 
        /// Constraints:
        ///     1. The input is never null or empty
        ///     2. If there is no unique character, return the ASCII null character '\0'
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract char FindFirstUniqueCharacter(string input);
    }
}
