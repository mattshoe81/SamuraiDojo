﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.SamuraiStats;
using SamuraiDojo.Stats;

namespace SamuraiDojo.Attributes
{
    public class SenseiAttribute : Attribute
    {
        public string Name { get; set; }

        public SenseiAttribute(string sensei)
        {
            Name = sensei;
            ScoreKeeper.RegisterSensei(sensei);
        }
    }
}
