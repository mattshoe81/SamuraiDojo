using SamuraiDojo.Attributes;
using System.Linq;

namespace SamuraiDojo.Battles.Week5
{
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : Snowflake
    {
        public override char FindFirstUniqueCharacter(string input)
        {
            char snowflake = '\0';

            snowflake = input.GroupBy(c => c).Where(g => g.Count() == 1).Select(g => g.Key).FirstOrDefault();
            
            return snowflake;
        }
    }
}