using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class ChallengeAttribute : Attribute
    {
        public string Name { get; set; }
        public int Week { get; set; }

        public ChallengeAttribute(string name, int week)
        {
            Name = name;
            Week = week;
        }
    }
}
