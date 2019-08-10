using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class WrittenByAttribute : Attribute
    {
        public string Name { get; set; }

        public WrittenByAttribute(string samurai)
        {
            Name = samurai;
        }
    }
}
