using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Scoring
{
    internal class ScoreKeeper : IScoreKeeper
    {
        public void Start()
        {
            Factory.Get<IAuditor>(Auditor.DOJO.ToString()).Audit();
            Factory.Get<IAuditor>(Auditor.TEST.ToString()).Audit();
            Factory.Get<IRankCalculator>().Calculate();
        }
    }
}
