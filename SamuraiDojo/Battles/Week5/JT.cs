using SamuraiDojo.Attributes;
using System.Linq;

namespace SamuraiDojo.Battles.Week5
{
    [WrittenBy(Samurai.JT)]
    public class JT : Snowflake
    {
        public override char FindFirstUniqueCharacter(string input) => input.GroupBy(x => x).Where(g => g.Count() == 1).Select(g => g.Key).FirstOrDefault();
    }
}
