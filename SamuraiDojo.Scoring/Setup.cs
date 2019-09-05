using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Scoring.Auditors;
using SamuraiDojo.Scoring.Interfaces;

namespace SamuraiDojo.Scoring
{
    public class Setup : IProjectSetup
    {
        public bool HasBeenInitialized { get; set; }

        public void Initialize()
        {
            BindToIOC();

            HasBeenInitialized = true;
        }

        private void BindToIOC()
        {
            Factory.Bind<IRankCalculator>(typeof(RankCalculator));
            Factory.Bind<IDojoAuditor>(typeof(DojoAuditor));
            Factory.Bind<ITestAuditor>(typeof(TestAuditor));
            Factory.Bind<IScoreKeeper>(typeof(ScoreKeeper));
        }
    }
}
