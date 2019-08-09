using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class SolutionByAttribute : Attribute
    {
        public string Name { get; set; }

        public SolutionByAttribute(string samurai)
        {
            Name = samurai;
        }
    }
}
