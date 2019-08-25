using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class Page
    {
        public string Name { get; set; }

        public DateTime TimeStamp { get; private set; }

        public Page()
        {
            TimeStamp = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            bool equals = this.StandardEquals(
                obj,
                other => other.Name == Name
            );
            return equals;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}