using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.Core.Factory;

namespace Tarject.Tests.Editor.Factory
{
    internal class ObjectFactoryTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.BindFactory<FactoryTestClass.Factory>();
            Container.BindFactory<FactorySingleParamTestClass.Factory>();
            Container.BindFactory<FactoryMultipleParamTestClass.Factory>();
            Container.BindFactory<FactoryInjectionTestClass.Factory>();
            Container.Bind<FactoryBindableClass>().Lazy();
        }

        [Test]
        public void Create()
        {
            FactoryTestClass.Factory factory = Container.Resolve<FactoryTestClass.Factory>();
            FactoryTestClass createdObject = factory.Create();

            Assert.IsNotNull(createdObject);
        }

        [Test]
        public void Create_With_Param1()
        {
            const string param = "factoryParam";
            
            FactorySingleParamTestClass.Factory factory = Container.Resolve<FactorySingleParamTestClass.Factory>();
            FactorySingleParamTestClass createdObject = factory.Create(param);

            Assert.IsNotNull(createdObject);
            Assert.IsTrue(createdObject.Param == param);
        }
        
        [Test]
        public void Create_With_Param2()
        {
            const int id = 26;
            const string name = "tariksavas";
            
            FactoryMultipleParamTestClass.Factory factory = Container.Resolve<FactoryMultipleParamTestClass.Factory>();
            FactoryMultipleParamTestClass createdObject = factory.Create(id, name);

            Assert.IsNotNull(createdObject);
            Assert.IsTrue(createdObject.Id == id);
            Assert.IsTrue(createdObject.Name == name);
        }
        
        [Test]
        public void Injection_After_Create()
        {
            FactoryInjectionTestClass.Factory factory = Container.Resolve<FactoryInjectionTestClass.Factory>();
            FactoryInjectionTestClass createdObject = factory.Create();

            Assert.IsNotNull(createdObject);
            Assert.IsNotNull(createdObject.factoryBindableClass);
        }

        private class FactoryTestClass : IFactorable
        {
            public class Factory : SeparatedObjectFactory<FactoryTestClass> { }
        }

        private class FactorySingleParamTestClass : IFactorable<string>
        {
            public string Param {  get; private set; }

            public void InitializeFactory(string param)
            {
                Param = param;
            }

            public class Factory : SeparatedObjectFactory<FactorySingleParamTestClass, string> { }
        }

        private class FactoryMultipleParamTestClass : IFactorable<int, string>
        {
            public int Id { get; private set; }

            public string Name { get; private set; }

            public void InitializeFactory(int param1, string param2)
            {
                Id = param1;
                Name = param2;
            }

            public class Factory : SeparatedObjectFactory<FactoryMultipleParamTestClass, int ,string> { }
        }

        private class FactoryInjectionTestClass : IFactorable
        {
            public readonly FactoryBindableClass factoryBindableClass;

            public FactoryInjectionTestClass(FactoryBindableClass factoryBindableClass)
            {
                this.factoryBindableClass = factoryBindableClass;
            }

            public class Factory : SeparatedObjectFactory<FactoryInjectionTestClass> { }
        }

        private class FactoryBindableClass
        {

        }
    }
}