using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;

namespace Tarject.Tests.Editor.Core
{
    public class ContainerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<BindTestClass>();

            BindFromInstanceTestClass instance = new BindFromInstanceTestClass("testInstance");
            Container.BindFromInstance<BindFromInstanceTestClass>(instance);

            Container.Bind<BindWithIdTestClass>().WithId("testId");

            Container.Bind<BindToInterfaceTestFirstClass>().ToInterface<IBindToInterfaceTestInterface>();
            Container.Bind<BindToInterfaceTestSecondClass>().ToInterface<IBindToInterfaceTestInterface>();

            Container.Bind<BindToInterfaceConcreteClass>();
        }

        [Test]
        public void Resolve_Bind()
        {
            BindTestClass bindTestClass = Container.Resolve<BindTestClass>();

            Assert.IsNotNull(bindTestClass);
        }

        [Test]
        public void Resolve_BindFromInstance()
        {
            BindFromInstanceTestClass bindFromInstanceTestClass = Container.Resolve<BindFromInstanceTestClass>();

            Assert.IsTrue(bindFromInstanceTestClass.Name == "testInstance");
        }

        [Test]
        public void Resolve_Bind_WithId()
        {
            BindWithIdTestClass bindWithIdTestClass = Container.Resolve<BindWithIdTestClass>(id: "testId");

            Assert.IsNotNull(bindWithIdTestClass);
        }

        [Test]
        public void Resolve_Bind_ToInterface()
        {
            IBindToInterfaceTestInterface bindToInterfaceTestInterface = Container.Resolve<IBindToInterfaceTestInterface>();

            Assert.IsNotNull(bindToInterfaceTestInterface);
        }

        [Test]
        public void Resolve_All_Bind_ToInterface()
        {
            BindToInterfaceConcreteClass bindToInterfaceConcreteClass = Container.Resolve<BindToInterfaceConcreteClass>();

            Assert.IsNotNull(bindToInterfaceConcreteClass);
            Assert.IsTrue(bindToInterfaceConcreteClass.GetInterfaceLength == 2);
        }

        private class BindTestClass
        {
        }

        private class BindWithIdTestClass
        {
        }

        private class BindToInterfaceTestFirstClass : IBindToInterfaceTestInterface
        {
        }

        private class BindToInterfaceTestSecondClass : IBindToInterfaceTestInterface
        {
        }

        private interface IBindToInterfaceTestInterface
        {
        }

        private class BindToInterfaceConcreteClass
        {
            private readonly IBindToInterfaceTestInterface[] _interfaces;

            public BindToInterfaceConcreteClass(IBindToInterfaceTestInterface[] interfaces)
            {
                _interfaces = interfaces;
            }

            public int GetInterfaceLength => _interfaces.Length;
        }

        private class BindFromInstanceTestClass
        {
            public readonly string Name;

            public BindFromInstanceTestClass(string name)
            {
                Name = name;
            }
        }
    }
}