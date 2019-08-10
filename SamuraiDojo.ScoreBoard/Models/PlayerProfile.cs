using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.Stats;

namespace SamuraiDojo.ScoreBoard.Models
{
    public class PlayerProfile
    {
        public string UserName { get; set; }    

        public int TotalPoints { get; set; }

        public int ChallengesCompleted { get; set; }

        public float SuccessRatio { get; set; }

        public PlayerStats Score { get; set; }

        public int Rank { get; set; }

    }
}