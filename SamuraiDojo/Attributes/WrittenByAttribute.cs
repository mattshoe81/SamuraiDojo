using System;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Attributes
{
    public class WrittenByAttribute : Attribute, IWrittenByAttribute
    {
        public string Name { get; set; }

        public WrittenByAttribute() { }

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
