using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;

namespace Tarject.Tests.Editor.Core
{
    public class ContainerTest : TarjectUnitTestFixture
    {
        private const string ID = "testId";
        private const string INSTANCE_NAME = "testInstance";
        private const string ARRAY_INSTANCE_NAME_FIRST = "testArrayInstance1";
        private const string ARRAY_INSTANCE_NAME_SECOND = "testArrayInstance2";
        
        protected override void Setup()
        {
            Container.Bind<BindTestClass>();

            BindFromInstanceTestClass instance = new BindFromInstanceTestClass(INSTANCE_NAME);
            Container.BindFromInstance(instance);

            BindFromInstanceTestClass[] arrayInstance = { new(ARRAY_INSTANCE_NAME_FIRST), new(ARRAY_INSTANCE_NAME_SECOND) };
            Container.BindFromInstance(arrayInstance);

            Container.Bind<BindWithIdTestClass>().WithId(ID);

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
        public void Resolve_Bind_From_Instance()
        {
            BindFromInstanceTestClass bindFromInstanceTestClass = Container.Resolve<BindFromInstanceTestClass>();

            Assert.IsTrue(bindFromInstanceTestClass.Name == INSTANCE_NAME);
        }

        [Test]
        public void Resolve_Bind_Array_From_Instance()
        {
            BindFromInstanceTestClass[] bindFromInstanceTestClass = Container.Resolve<BindFromInstanceTestClass[]>();

            Assert.IsTrue(bindFromInstanceTestClass[0].Name == ARRAY_INSTANCE_NAME_FIRST);
            Assert.IsTrue(bindFromInstanceTestClass[1].Name == ARRAY_INSTANCE_NAME_SECOND);
        }

        [Test]
        public void Resolve_Bind_WithId()
        {
            BindWithIdTestClass bindWithIdTestClass = Container.Resolve<BindWithIdTestClass>(id: ID);

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