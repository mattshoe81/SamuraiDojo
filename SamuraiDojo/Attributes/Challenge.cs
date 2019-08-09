using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class Challenge : Attribute
    {
        public string Name { get; set; }

        public Challenge(string name)
        {
            Name = name;
        }
    }
}
