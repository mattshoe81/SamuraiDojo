using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week4
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : Palindromania
    {
        public override string LargestPalindrome(string input)
        {
            string largestPalindrome = "";

            for (int i = 0; i < input.Length; i++)
            {
                string oddLengthPalindrome = GetOddLengthPalindrome(i, input);
                string evenLengthPalindrome = GetEvenLengthPalindrome(i, input);

                if (evenLengthPalindrome.Length > largestPalindrome.Length)
                    largestPalindrome = evenLengthPalindrome;

                if (oddLengthPalindrome.Length > largestPalindrome.Length)
                    largestPalindrome = oddLengthPalindrome;
            }

            return largestPalindrome;
        }

        private string GetOddLengthPalindrome(int startingPoint, string input)
        {
            string result = input[startingPoint].ToString();
            int offset = 1;

            if (startingPoint != input.Length - 1)
            {
                while (startingPoint + offset < input.Length && startingPoint - offset >= 0)
                {
                    string front = input[startingPoint - offset].ToString().ToUpper();
                    string back = input[startingPoint + offset].ToString().ToUpper();

                    if (front == back)
                        result = front + result + back;
                    else
                        break;

                    offset++;
                }
            }

            return result;
        }

        private string GetEvenLengthPalindrome(int startingPoint, string input)
        {
            string result = input[startingPoint].ToString().ToUpper();

            if (startingPoint == input.Length - 1 || result != input[startingPoint + 1].ToString().ToUpper())
                return result;
            else
                result += input[startingPoint + 1].ToString().ToUpper();

            int offset = 1;
            while (startingPoint + offset + 1 < input.Length && startingPoint - offset >= 0)
            {
                string front = input[startingPoint - offset].ToString().ToUpper();
                string back = input[startingPoint + offset + 1].ToString().ToUpper();

                if (front == back)
                    result = front + result + back;
                else
                    break;

                offset++;
            }

            return result;
        }
    }
}
