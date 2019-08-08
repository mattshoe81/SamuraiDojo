using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Attributes
{
    public class Sensei : Attribute
    {
        public Sensei(string sensei)
        {
            Samurai.AddSensei(sensei);
        }
    }
}
