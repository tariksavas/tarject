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
            Container.Bind<DerivedClass>();
        }

        [Test]
        public void Get_Injectable_Constructor()
        {
            Type type = typeof(SingleInjectConstructorTestClass);
            ConstructorInfo constructorInfo = type.GetCachedInjectableConstructor();

            Assert.IsNotNull(constructorInfo);
            Assert.IsTrue(constructorInfo.GetParameters().Length > 0);
        }

        [Test]
        public void Get_Injectable_Constructor_With_Attribute()
        {
            Type type = typeof(MultipleInjectConstructorWithAttributeTestClass);
            ConstructorInfo constructorInfo = type.GetCachedInjectableConstructor();

            Assert.IsNotNull(constructorInfo);
            Assert.IsTrue(constructorInfo.GetParameters().Length == 1);
        }

        [Test]
        public void Get_More_Injectable_Constructor()
        {
            Type type = typeof(MultipleInjectConstructorTestClass);
            ConstructorInfo constructorInfo = type.GetCachedInjectableConstructor();

            Assert.IsNotNull(constructorInfo);
            Assert.IsTrue(constructorInfo.GetParameters().Length == 2);
        }

        [Test]
        public void Get_Injectable_Parameter_Objects()
        {
            Type type = typeof(SingleInjectConstructorTestClass);
            Assert.IsTrue(type.TryGetDependencies(out object[] objects, Container));
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

        [Test]
        public void Inject_With_Base_Type()
        {
            DerivedClass derivedClass = Container.Resolve<DerivedClass>();

            Assert.IsNotNull(derivedClass);
            Assert.IsNotNull(derivedClass?.singleInjectionTestClass);
            Assert.IsNotNull(derivedClass?.multipleInjectionTestClass);
        }

        [Test]
        public void Get_Fields_With_Base_Type_Fields()
        {
            Type type = typeof(DerivedClass);
            FieldInfo[] fields = type.GetCachedFields();

            Assert.IsTrue(fields[0].FieldType == typeof(SingleInjectionTestClass));
            Assert.IsTrue(fields[1].FieldType == typeof(MultipleInjectionTestClass));
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

        private class BaseClass
        {
            public readonly SingleInjectionTestClass singleInjectionTestClass;

            public BaseClass(SingleInjectionTestClass singleInjectionTestClass)
            {
                this.singleInjectionTestClass = singleInjectionTestClass;
            }
        }

        private class DerivedClass : BaseClass
        {
            public readonly MultipleInjectionTestClass multipleInjectionTestClass;

            public DerivedClass(SingleInjectionTestClass singleInjectionTestClass, MultipleInjectionTestClass multipleInjectionTestClass) : base(singleInjectionTestClass)
            {
                this.multipleInjectionTestClass = multipleInjectionTestClass;
            }
        }
    }
}