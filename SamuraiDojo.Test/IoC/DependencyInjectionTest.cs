using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces.Test;
using SamuraiDojo.Test.IoC.Models;

namespace SamuraiDojo.Test.IoC
{
    [TestClass]
    public class DependencyInjectionTest
    {
        [TestInitialize]
        public void Setup()
        {
            Factory.Reset();
            Factory.Bind<IChild1>(typeof(Child1));
            Factory.Bind<IChild2>(typeof(Child2));
            Factory.Bind<IParent>(typeof(Parent));
            Factory.Bind<INestedParent>(typeof(NestedParent));
        }

        [TestMethod]
        public void TwoDependencies_NonNested()
        {
            IParent parent = Factory.Get<IParent>();
            IChild1 child1 = parent.Child1;
            IChild2 child2 = parent.Child2;

            Assert.IsNotNull(parent, "Parent is null");
            Assert.IsNotNull(child1, "Child 1 is null");
            Assert.IsNotNull(child2, "Child 2 is null");
        }

        [TestMethod]
        public void NestedDependencies()
        {
            INestedParent topLevelParent = Factory.Get<INestedParent>();
            IParent parent = topLevelParent.ParentNested;
            IChild1 child1 = parent.Child1;
            IChild2 child2 = parent.Child2;

            Assert.IsNotNull(topLevelParent, "Top level parent is null");
            Assert.IsNotNull(parent, "Nested Parent is null");
            Assert.IsNotNull(child1, "Child 1 is null");
            Assert.IsNotNull(child2, "Child 2 is null");
        }

        [TestMethod]
        public void MissingDependency()
        {
            Factory.Reset();
            Factory.Bind<IChild2>(typeof(Child2));
            Factory.Bind<IParent>(typeof(Parent));
            Factory.Bind<INestedParent>(typeof(NestedParent));

            Assert.ThrowsException<InvalidOperationException>(() => Factory.Get<INestedParent>());

            // Restore bindings
            Setup();
        }
        
        [TestMethod]
        public void InvalidBind_NonImplementation()
        {
            Assert.ThrowsException<InvalidCastException>(() => Factory.Bind<IChild1>(typeof(Child2)));
        }

        [TestMethod]
        public void InvalidBind_NonInterfaceType()
        {
            Assert.ThrowsException<InvalidCastException>(() => Factory.Bind<Child1>(typeof(Child1)));
        }

        [TestMethod]
        public void InvalidBind_ImplementationAsInterface()
        {
            Assert.ThrowsException<InvalidCastException>(() => Factory.Bind<IChild1>(typeof(IChild1)));
        }

        [TestMethod]
        public void InvalidBind_Backwards()
        {
            Assert.ThrowsException<InvalidCastException>(() => Factory.Bind<Child1>(typeof(IChild1)));
        }


    }
}
