using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;

namespace SamuraiDojo.Scoring
{
    public class ScoreKeeper
    {
        public static void Start()
        {
            Factory.New<IAuditor>(Auditor.DOJO.ToString()).Audit();
            Factory.New<IAuditor>(Auditor.TEST.ToString()).Audit();
            Factory.Get<IRankCalculator>().Calculate();
        }
    }
}
