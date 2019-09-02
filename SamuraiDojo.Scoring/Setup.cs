using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Scoring.Auditors;

namespace SamuraiDojo.Scoring
{
    public class Setup : ProjectSetup
    {
        protected override bool HasBeenInitialized { get; set; }

        protected override void Initialize()
        {
            new SamuraiDojo.Setup();
            new SamuraiDojo.Utility.Setup();
            new SamuraiDojo.Test.Setup();

            BindToIOC();

            Factory.Get<IScoreKeeper>().Start();

            HasBeenInitialized = true;
        }

        private void BindToIOC()
        {
            Factory.Bind<IRankCalculator>(typeof(RankCalculator));
            Factory.Bind<IScoreKeeper>(typeof(ScoreKeeper));
            Factory.Bind<IDojoAuditor>(typeof(DojoAuditor));
            Factory.Bind<ITestAuditor>(typeof(TestAuditor));
        }
    }

    public enum Auditor
    {
        DOJO,
        TEST
    }
}
