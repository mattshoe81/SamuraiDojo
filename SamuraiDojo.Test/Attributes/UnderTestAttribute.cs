using System;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Test.Interfaces;

namespace SamuraiDojo.Test.Attributes
{
    public class UnderTestAttribute : Attribute, IUnderTestAttribute
    {
        public Type Type { get; set; }

        public UnderTestAttribute() { }

        public UnderTestAttribute(Type type)
        {
            Type = type;
        }
    }
}
