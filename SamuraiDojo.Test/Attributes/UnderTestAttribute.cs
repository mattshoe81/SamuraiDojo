using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Test.Attributes
{
    public class UnderTestAttribute : Attribute
    {
        public Type Type { get; set; }

        public UnderTestAttribute(Type type)
        {
            Type = type;
        }
    }
}
