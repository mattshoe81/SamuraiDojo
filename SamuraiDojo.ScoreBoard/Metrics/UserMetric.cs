using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class UserMetric
    {
        public string IP { get; set; }

        public HashSet<string> Sessions { get; set; }

        public HashSet<string> Usernames { get; set; }

        public UserMetric()
        {
            Sessions = new HashSet<string>();
            Usernames = new HashSet<string>();
        }
    }
}