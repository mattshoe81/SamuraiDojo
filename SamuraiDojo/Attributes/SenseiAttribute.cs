using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Repositories;

namespace SamuraiDojo.Attributes
{
    public class SenseiAttribute : Attribute, ISenseiAttribute
    {
        public string Name { get; set; }

        public SenseiAttribute(string sensei)
        {
            Name = sensei;
        }
    }
}
