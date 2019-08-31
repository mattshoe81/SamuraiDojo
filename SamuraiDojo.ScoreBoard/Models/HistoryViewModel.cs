using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Models;

namespace SamuraiDojo.ScoreBoard.Models
{
    public class HistoryViewModel
    {
        public List<IBattleOutcome> Battles { get; set; }    

        public HistoryViewModel()
        {
            Battles = new List<IBattleOutcome>();
        }
    }
}