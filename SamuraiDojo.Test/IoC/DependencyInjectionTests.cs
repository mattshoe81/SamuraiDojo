﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces.Test;
using SamuraiDojo.Test.IoC.Models;

namespace SamuraiDojo.Test.IoC
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [TestInitialize]
        public void Setup()
        {
            Dojector.Bind<IChild1>(typeof(Child1));
            Dojector.Bind<IChild2>(typeof(Child2));
            Dojector.Bind<IParent>(typeof(Parent));
            Dojector.Bind<INestedParent>(typeof(NestedParent));
        }

        [TestCleanup]
        public void Cleanup()
        {
            Dojector.Reset();
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
            Dojector.Reset();
            Dojector.Bind<IChild2>(typeof(Child2));
            Dojector.Bind<IParent>(typeof(Parent));
            Dojector.Bind<INestedParent>(typeof(NestedParent));

            Assert.ThrowsException<InvalidOperationException>(() => Factory.Get<INestedParent>());
        }
        
        [TestMethod]
        public void InvalidBind_NonImplementation()
        {
            Assert.ThrowsException<InvalidCastException>(() => Dojector.Bind<IChild1>(typeof(Child2)));
        }

        [TestMethod]
        public void InvalidBind_NonInterfaceType()
        {
            Assert.ThrowsException<InvalidCastException>(() => Dojector.Bind<Child1>(typeof(Child1)));
        }

        [TestMethod]
        public void InvalidBind_ImplementationAsInterface()
        {
            Assert.ThrowsException<InvalidCastException>(() => Dojector.Bind<IChild1>(typeof(IChild1)));
        }

        [TestMethod]
        public void InvalidBind_Backwards()
        {
            Assert.ThrowsException<InvalidCastException>(() => Dojector.Bind<Child1>(typeof(IChild1)));
        }

        [TestMethod]
        public void Parent_MultipleConstructors()
        {
            Dojector.Bind<IParent>(typeof(ParentMultipleConstructors));

            IParent parent = Factory.Get<IParent>();
            IChild1 child1 = parent.Child1;
            IChild2 child2 = parent.Child2;

            Assert.IsNotNull(parent, "Parent is null");
            Assert.IsNotNull(child1, "Child 1 is null");
            Assert.IsNotNull(child2, "Child 2 is null");
        }

        [TestMethod]
        public void Singleton_NoDependencies()
        {
            Dojector.Reset();
            Dojector.Bind<IChild1>(typeof(Child1), BindingConfig.Singleton);

            IChild1 instance1 = Factory.Get<IChild1>();
            IChild1 instance2 = Factory.Get<IChild1>();

            Assert.IsNotNull(instance1, "Instance 1 is null");
            Assert.IsNotNull(instance2, "Instance 2 is null");
            Assert.IsTrue(instance1.Name == instance2.Name, $"Instance names do not match. Instance1: {instance1.Name}, instance2: {instance2.Name}");

            instance1.Name = "Changed";
            Assert.IsTrue(instance1.Name == instance2.Name, $"Instance names do not match after change. Instance1: {instance1.Name}, instance2: {instance2.Name}");
        }

        [TestMethod]
        public void Debind_BrokenDependency()
        {
            Dojector.Debind<IChild1>();

            Assert.ThrowsException<InvalidOperationException>(() => Factory.Get<IParent>());
        }

        [TestMethod]
        public void Debind_NullInstance()
        {
            Dojector.Debind<IChild1>();
            IChild1 child1 = Factory.Get<IChild1>();

            Assert.IsNull(child1, "Child1 was debound but is not null on retrieval");
        }

        [TestMethod]
        public void NullImplementation()
        {
            Assert.ThrowsException<InvalidOperationException>(() => Dojector.Bind<IChild1>(null));
        }

        [TestMethod]
        public void CircularDependency_Singleton()
        {
            Dojector.Reset();
            Dojector.Bind<ICircularDependency1>(typeof(CircularDependency1), BindingConfig.Singleton);
            Dojector.Bind<ICircularDependency2>(typeof(CircularDependency2), BindingConfig.Singleton);
            Assert.ThrowsException<InvalidOperationException>(() => Dojector.Resolve());
        }



    }
}
