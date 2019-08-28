using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.Models;

namespace SamuraiDojo.ScoreBoard.Models
{
    public class HistoryViewModel
    {
        public List<BattleOutcome> Battles { get; set; }    

        public HistoryViewModel()
        {
            Battles = new List<BattleOutcome>();
        }
    }
}