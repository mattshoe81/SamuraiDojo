using System;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.Attributes.Bonus
{
    public abstract class BonusPointsAttribute : Attribute, IBonusPointsAttribute
    {
        public abstract int Points { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
    }
}
