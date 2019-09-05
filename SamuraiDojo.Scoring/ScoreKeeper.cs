using SamuraiDojo.Scoring.Interfaces;

namespace SamuraiDojo.Scoring
{
    internal class ScoreKeeper : IScoreKeeper
    {
        IDojoAuditor dojoAuditor;
        ITestAuditor testAuditor;
        IRankCalculator rankCalculator;

        public ScoreKeeper(
            ITestAuditor testAuditor,
            IDojoAuditor dojoAuditor,
            IRankCalculator rankCalculator)
        {
            this.dojoAuditor = dojoAuditor;
            this.testAuditor = testAuditor;
            this.rankCalculator = rankCalculator;
        }

        public void Start()
        {
            dojoAuditor.Audit();
            testAuditor.Audit();
            rankCalculator.Calculate();
        }
    }
}
