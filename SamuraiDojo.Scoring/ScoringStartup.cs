using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Intefaces;
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
