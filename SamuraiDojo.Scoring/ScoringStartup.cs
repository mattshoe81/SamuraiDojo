using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Scoring.Auditors;

namespace SamuraiDojo.Scoring
{
    public class ScoringStartup : IProjectStartup
    {
        public void ProjectInit()
        {
            BindToIOC();
            ScoreKeeper.Start();
        }

        private void BindToIOC()
        {
            Factory.Bind<IRankCalculator>(typeof(RankCalculator));
            Factory.MultiBind<IAuditor>(Auditor.DOJO.ToString(), typeof(DojoAuditor));
            Factory.MultiBind<IAuditor>(Auditor.TEST.ToString(), typeof(TestAuditor));
        }
    }

    public enum Auditor
    {
        DOJO,
        TEST
    }
}
