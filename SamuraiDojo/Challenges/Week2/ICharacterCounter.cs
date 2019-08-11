using SamuraiDojo.Attributes;

namespace SamuraiDojo.Challenges.Week2
{
    [Challenge("8/16/19", "Permutations of Character")]
    public interface ICharacterCounter
    {
        /// <summary>
        /// 
        /// THIS ONE'S A DOOZY! You guys solved the Clock Angler too easily! Time for a more worthy challenge:
        /// 
        /// Given a string of integers (i.e. "65743243263286740547241403725756"), determine the maximum number
        /// of alphabetic characters that we could have mapped according to the following map of 
        /// integers to alphabetic characters. You ONLY need to count the number of possible characters you 
        /// could have mapped from the string. You do not need to construct any new strings. This is just a 
        /// maximization algorithm.
        /// 
        /// Character Map:
        ///     A = 1,
        ///     B = 2,
        ///     C = 3,
        ///     .
        ///     .
        ///     .
        ///     X = 24,
        ///     Y = 25,
        ///     z = 26
        /// 
        /// ASSUMPTIONS:
        ///     - You may assume all characters are an integer 1-9 (zero is not allowed)
        ///     - You may assume you will never receive an empty string
        ///     - You may assume every character will be an integer
        ///     
        /// Examples:
        ///     "123"  => 5 since [1=A, 2=B, 3=C, 12=L, 23=W]. Thus we could have mapped 5 characters given this string.
        ///     "2412" => 6 since [2=B, 4=D, 1=A, 2=B, 24=X, 12=L]. Thus we could have mapped 6 characters given this string. (NOTICE we do count duplicates!)
        ///     "927"  => 3 since [9=I, 2=B, 7=G]. Thus we could have mapped only 3 characters given this string.
        ///     "7321" => 5 since [7=G, 3=C, 2=B, 1=A, 21=U]. Thus we could have mapped 5 possible characters given this string.
        ///     "99"   => 2 since [9=I, 9=I]. Thus we could have mapped 2 characters given the string. (note that duplicates DO count)
        /// 
        /// NOTES:
        ///     - There DOES exist an algorithm to perform this search in linear time (i.e. with a SINGLE loop).
        ///     - The most elegant solution should NOT use any arrays or collections to check any mapping.
        ///     - You are NOT required to implement it in linear time, but you will earn extra points if you 
        ///       are the most efficient solution!
        /// 
        /// </summary>
        /// <param name="integers">A string whose characters are all some integer between 1-9 inclusive.</param>
        /// <returns>
        ///     The maximum number of possible alphabetic characters that could have been mapped from the string of 
        ///     integers, where A=1, B=2, C=3, ... , Y=25, Z=26.
        /// </returns>
        int CountPossibleCharacters(string integers);
    }
}
