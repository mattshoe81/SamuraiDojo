using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class Session
    {
        public string SessionID { get; set; }

        public string IP { get; set; }

        public string HostName { get; set; }

        public string Browser { get; set; }

        public string Username { get; set; }

        public List<Page> PageLoads { get; set; }

        public Session()
        {
            PageLoads = new List<Page>();
        }

        public override bool Equals(object obj)
        {
            bool equals = this.StandardEquals(
                obj, 
                (other) => SessionID == other.SessionID
            );

            return equals;
        }

        public override int GetHashCode()
        {
            return SessionID.GetHashCode();
        }
    }
}