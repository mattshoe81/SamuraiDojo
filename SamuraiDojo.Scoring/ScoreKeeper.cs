using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Scoring
{
    public class ScoreKeeper
    {
        public static void Start()
        {
            DojoAuditor.Audit();
            TestAuditor.Audit();
            RankCalculator.Calculate();
        }       
    }
}
