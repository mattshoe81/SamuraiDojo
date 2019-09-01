using SamuraiDojo.IoC.Interfaces.Test;

namespace SamuraiDojo.Test.IoC.Models
{
    internal class Parent : IParent
    {
        public IChild1 Child1 { get; set; }

        public IChild2 Child2 { get; set; }

        public Parent(IChild1 child1, IChild2 child2)
        {
            Child1 = child1;
            Child2 = child2;
        }

        public int Prop { get; set; }
    }
}
