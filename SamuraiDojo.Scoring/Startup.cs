using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Scoring.Auditors;

namespace SamuraiDojo.Scoring
{
    public class Startup : IProjectSetup
    {
        private static bool initialized = false;

        public void Initialize()
        {
            if (!initialized)
            {
                BindToIOC();
                Factory.Get<IScoreKeeper>().Start();

                initialized = true;
            }
        }

        private void BindToIOC()
        {
            Factory.Bind<IRankCalculator>(typeof(RankCalculator));
            Factory.Bind<IScoreKeeper>(typeof(ScoreKeeper));
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
