using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week6
{
    [WrittenBy(Samurai.JT)]
    public class JT : SuperfluousSansLoop
    {
        public override string Print1toNWithoutLoops(int n) => (n > 0) ? Print1toNWithoutLoops(--n) + ", " + (n + 1).ToString() : n.ToString();
    }
}
