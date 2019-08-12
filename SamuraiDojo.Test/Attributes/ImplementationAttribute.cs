using System;

namespace SamuraiDojo.Test.Attributes
{
    public class ImplementationAttribute : Attribute
    {
        public Type Type { get; set; }

        public ImplementationAttribute(Type type)
        {
            Type = type;
        }
    }
}
