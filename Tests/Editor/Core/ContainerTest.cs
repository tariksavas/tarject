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

            Container.Bind<BindToInterfaceTestClass>().ToInterface<IBindToInterfaceTestInterface>();
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

        private class BindTestClass
        {
        }

        private class BindWithIdTestClass
        {
        }

        private class BindToInterfaceTestClass : IBindToInterfaceTestInterface
        {
        }

        private interface IBindToInterfaceTestInterface
        {
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