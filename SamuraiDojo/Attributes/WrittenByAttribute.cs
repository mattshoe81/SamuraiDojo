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
            Name = samurai.ToUpper();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (object.ReferenceEquals(this, obj))
                return true;
            else if (obj is WrittenByAttribute)
                return Name == ((WrittenByAttribute)obj).Name;

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
