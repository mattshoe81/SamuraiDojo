using SamuraiDojo.Scoring.Auditors;

namespace SamuraiDojo.Scoring
{
    public class ScoreKeeper
    {
        public static void Start()
        {
            new DojoAuditor().Audit();
            new TestAuditor().Audit();
            new RankCalculator().Calculate();
        }
    }
}
