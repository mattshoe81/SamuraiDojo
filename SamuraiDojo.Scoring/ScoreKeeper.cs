using SamuraiDojo.Scoring.Auditors;
using SamuraiDojo.Scoring.Interfaces;

namespace SamuraiDojo.Scoring
{
    public class ScoreKeeper
    {
        public static void Start()
        {
            Factory.New(Auditor.DOJO).Audit();
            Factory.New(Auditor.TEST).Audit();
            Factory.New<IRankCalculator>().Calculate();
        }
    }
}
