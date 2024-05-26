using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.Core.Factory;

namespace Tarject.Tests.Editor.Factory
{
    internal class ObjectFactoryTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.BindFactory<ObjectFactory>();
        }

        [Test]
        public void Create()
        {
            ObjectFactory factory = Container.Resolve<ObjectFactory>();
            FactoryTestClass factoryTestClass = factory.Create<FactoryTestClass>();

            Assert.IsNotNull(factoryTestClass);
        }

        [Test]
        public void Create_With_Param1()
        {
            ObjectFactory factory = Container.Resolve<ObjectFactory>();
            FactorySingleParamTestClass factoryTestClass = factory.Create<FactorySingleParamTestClass, string>("factoryParam");

            Assert.IsNotNull(factoryTestClass);
            Assert.IsTrue(factoryTestClass.Param == "factoryParam");
        }
        
        [Test]
        public void Create_With_Param2()
        {
            ObjectFactory factory = Container.Resolve<ObjectFactory>();
            FactoryMultipleParamTestClass factoryTestClass = factory.Create<FactoryMultipleParamTestClass, int, string>(26, "tariksavas");

            Assert.IsNotNull(factoryTestClass);
            Assert.IsTrue(factoryTestClass.Id == 26);
            Assert.IsTrue(factoryTestClass.Name == "tariksavas");
        }
        
        [Test]
        public void Injection_After_Create()
        {
            ObjectFactory factory = Container.Resolve<ObjectFactory>();
            FactoryInjectionTestClass factoryTestClass = factory.Create<FactoryInjectionTestClass>();

            Assert.IsNotNull(factoryTestClass);
            Assert.IsNotNull(factoryTestClass.ObjectFactory);
        }

        private class FactoryTestClass : IFactory
        {
        }

        private class FactorySingleParamTestClass : IFactory<string>
        {
            public string Param {  get; private set; }

            public void InitializeFactory(string param)
            {
                Param = param;
            }
        }

        private class FactoryMultipleParamTestClass : IFactory<int, string>
        {
            public int Id { get; private set; }

            public string Name { get; private set; }

            public void InitializeFactory(int param1, string param2)
            {
                Id = param1;
                Name = param2;
            }
        }

        private class FactoryInjectionTestClass : IFactory
        {
            public readonly ObjectFactory ObjectFactory;

            public FactoryInjectionTestClass(ObjectFactory objectFactory)
            {
                ObjectFactory = objectFactory;
            }
        }
    }
}