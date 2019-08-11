using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Models
{
    public class ChallengeResult : IComparable<ChallengeResult>
    {
        public WrittenByAttribute Player { get; set; }

        public int Points { get; set; }

        public int CompareTo(ChallengeResult other)
        {
            int comparison = other.Points - Points;
            return comparison;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (object.ReferenceEquals(this, obj))
                return true;
            else if (obj is ChallengeResult)
                return Player.Name == ((ChallengeResult)obj).Player.Name;

            return false;
        }
    }
}
