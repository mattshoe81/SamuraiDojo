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
            Dojector.Bind<IRankCalculator>(typeof(RankCalculator));
            Dojector.Bind<IDojoAuditor>(typeof(DojoAuditor));
            Dojector.Bind<ITestAuditor>(typeof(TestAuditor));
            Dojector.Bind<IScoreKeeper>(typeof(ScoreKeeper));
        }
    }
}
