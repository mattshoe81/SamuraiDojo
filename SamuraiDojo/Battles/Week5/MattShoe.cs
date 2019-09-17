using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week5
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : Snowflake
    {
        public override char FindFirstUniqueCharacter(string input)
        {
            // Keep this set as a ledger of all characters we see, giving us a O(1) check for duplicates via Contains
            HashSet<char> allCharacters = new HashSet<char>();
            // First time we see a new char, store its value and index in this dictionary
            Dictionary<char, int> uniqueCharacters = new Dictionary<char, int>();

            // Only loop once
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                // If we've seen this character before, then remove it from the uniques since it has a duplicate
                if (allCharacters.Contains(current))
                    uniqueCharacters.Remove(current);
                // Otherwise we have an undiscovered char, so record its index and add it to the ledger
                else
                {
                    uniqueCharacters.Add(current, i);
                    allCharacters.Add(current);
                }
            }

            char snowflake = '\0';
            // If we have any unique characters, then find the one with the smallest index
            if (uniqueCharacters.Count > 0)
            {
                int index = uniqueCharacters.Min(entry => entry.Value);
                snowflake = input[index];
            }

            return snowflake;
        }
    }
}
