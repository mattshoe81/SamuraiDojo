﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class MostElegantAttribute : BonusPointsAttribute
    {
        public override int Points { get; } = 5;
    }
}
