using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class SolutionBy : Attribute
    {
        public string Name { get; set; }

        public SolutionBy(string samurai)
        {
            Name = samurai;
        }
    }
}
