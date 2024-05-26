using NUnit.Framework;
using Tarject.Runtime.Utility;
using System.Reflection;
using System;
using Tarject.Runtime.Core.Injecter;
using Tarject.Editor.TestFramework.UnitTest;

namespace Tarject.Tests.Editor.Utility
{
    public class InjectionHelperTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<SingleInjectionTestClass>();
            Container.Bind<MultipleInjectionTestClass>();
            Container.Bind<SingleInjectConstructorTestClass>();
        }

        [Test]
        public void Get_Injectable_Constructor()
        {
            Type type = typeof(SingleInjectConstructorTestClass);
            ConstructorInfo constructorInfo = type.GetInjectableConstructor();

            Assert.IsNotNull(constructorInfo);
            Assert.IsTrue(constructorInfo.GetParameters().Length > 0);
        }

        [Test]
        public void Get_Injectable_Constructor_With_Attribute()
        {
            Type type = typeof(MultipleInjectConstructorWithAttributeTestClass);
            ConstructorInfo constructorInfo = type.GetInjectableConstructor();

            Assert.IsNotNull(constructorInfo);
            Assert.IsTrue(constructorInfo.GetParameters().Length == 1);
        }

        [Test]
        public void Get_More_Injectable_Constructor()
        {
            Type type = typeof(MultipleInjectConstructorTestClass);
            ConstructorInfo constructorInfo = type.GetInjectableConstructor();

            Assert.IsNotNull(constructorInfo);
            Assert.IsTrue(constructorInfo.GetParameters().Length == 2);
        }

        [Test]
        public void Get_Injectable_Parameter_Objects()
        {
            Type type = typeof(SingleInjectConstructorTestClass);
            object[] objects= type.GetInjectableParameterObjects(Container);

            Assert.IsNotNull(objects);
            Assert.IsTrue(objects.Length > 0);
            Assert.IsNotNull(objects[0]);
        }

        [Test]
        public void Inject_Constructor()
        {
            SingleInjectConstructorTestClass testClass = Container.Resolve<SingleInjectConstructorTestClass>();

            Assert.IsNotNull(testClass);
            Assert.IsNotNull(testClass?.singleInjectionTestClass);
        }

        private class SingleInjectionTestClass
        {

        }
        
        private class MultipleInjectionTestClass
        {

        }

        private class SingleInjectConstructorTestClass
        {
            public readonly SingleInjectionTestClass singleInjectionTestClass;

            public SingleInjectConstructorTestClass(SingleInjectionTestClass singleInjectionTestClass)
            {
                this.singleInjectionTestClass = singleInjectionTestClass;
            }
        }

        private class MultipleInjectConstructorTestClass
        {
            public readonly SingleInjectionTestClass singleInjectionTestClass;

            public readonly MultipleInjectionTestClass multipleInjectionTestClass;

            public MultipleInjectConstructorTestClass(SingleInjectionTestClass singleInjectionTestClass)
            {
                this.singleInjectionTestClass = singleInjectionTestClass;
            }

            public MultipleInjectConstructorTestClass(SingleInjectionTestClass singleInjectionTestClass, MultipleInjectionTestClass multipleInjectionTestClass)
            {
                this.singleInjectionTestClass = singleInjectionTestClass;
                this.multipleInjectionTestClass = multipleInjectionTestClass;
            }
        }

        private class MultipleInjectConstructorWithAttributeTestClass
        {
            public readonly SingleInjectionTestClass singleInjectionTestClass;

            public readonly MultipleInjectionTestClass multipleInjectionTestClass;

            [Inject]
            public MultipleInjectConstructorWithAttributeTestClass(SingleInjectionTestClass singleInjectionTestClass)
            {
                this.singleInjectionTestClass = singleInjectionTestClass;
            }

            public MultipleInjectConstructorWithAttributeTestClass(SingleInjectionTestClass singleInjectionTestClass, MultipleInjectionTestClass multipleInjectionTestClass)
            {
                this.singleInjectionTestClass = singleInjectionTestClass;
                this.multipleInjectionTestClass = multipleInjectionTestClass;
            }
        }
    }
}