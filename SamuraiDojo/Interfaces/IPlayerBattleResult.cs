﻿using System;
using System.Collections.Generic;
using SamuraiDojo.Models;

namespace SamuraiDojo.Interfaces
{
    public interface IPlayerBattleResult : IComparable<IPlayerBattleResult>
    {
        List<IBonusPointsAttribute> Awards { get; set; }
        IEfficiencyResult Efficiency { get; set; }
        IWrittenByAttribute Player { get; set; }
        int Points { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}