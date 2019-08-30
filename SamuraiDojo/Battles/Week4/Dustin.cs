using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week4
{
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : Palindromania
    {
        public override string LargestPalindrome(string input)
        {
            input = input.ToUpper();

            string largestPalindrome = null;
            string checkString = null;
            bool foundPalindrome = false;

            for (int i = input.Length; i > 0; i--)
            {
                for (int j = 0; j <= input.Length - i; j++)
                {
                    checkString = input.Substring(j, i);
                    foundPalindrome = CheckForPalindrome(checkString);

                    if (foundPalindrome)
                    {
                        largestPalindrome = checkString;
                        return largestPalindrome;
                    }
                }
            }

            return largestPalindrome;

        }

        public bool CheckForPalindrome(string input)
        {
            bool result = false;
            string resultString = "";
            char[] characters = input.ToCharArray();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                resultString += characters[i];
            }

            if (resultString == input)
            {
                result = true;
            }

            return result;

        }
    }

}
