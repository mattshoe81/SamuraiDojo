using System.Collections.Generic;
using SamuraiDojo.Interfaces;

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