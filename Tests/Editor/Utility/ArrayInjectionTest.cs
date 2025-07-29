using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.Core.Injecter;

namespace Tarject.Tests.Editor.Utility
{
    public class ArrayInjectionTest : TarjectUnitTestFixture
    {
        private const string ARRAY_FIRST = "array1";
        private const string ARRAY_SECOND = "array2";
        
        protected override void Setup()
        {
            SampleTestClass sampleTestClass = new SampleTestClass();
            SampleTestClass[] sampleTestClasses = { new SampleTestClass(), new SampleTestClass() };
            
            Container.BindFromInstance(sampleTestClass).WithId(ARRAY_FIRST);
            Container.BindFromInstance(sampleTestClasses).WithId(ARRAY_SECOND);

            Container.Bind<OnlyArrayInjectionTestClass>();
            Container.Bind<ArrayFirstInjectionTestClass>();
            Container.Bind<ArraySecondInjectionTestClass>();
            Container.Bind<AllArrayInjectionTestClass>();
        }
        
        [Test]
        public void Inject_OnlyArray()
        {
            OnlyArrayInjectionTestClass testClass = Container.Resolve<OnlyArrayInjectionTestClass>();
            Assert.IsNotNull(testClass);
            Assert.IsNotNull(testClass?.sampleTestClass);
        }
        
        [Test]
        public void Inject_ArrayFirst()
        {
            ArrayFirstInjectionTestClass testClass = Container.Resolve<ArrayFirstInjectionTestClass>();
            Assert.IsNotNull(testClass);
            Assert.IsNotNull(testClass?.sampleTestClasses);
            Assert.IsTrue(testClass?.sampleTestClasses.Length == 1);
        }
        
        [Test]
        public void Inject_ArraySecond()
        {
            ArraySecondInjectionTestClass testClass = Container.Resolve<ArraySecondInjectionTestClass>();
            Assert.IsNotNull(testClass);
            Assert.IsNotNull(testClass?.sampleTestClasses);
            Assert.IsTrue(testClass?.sampleTestClasses.Length == 2);
        }
        
        [Test]
        public void Inject_All()
        {
            AllArrayInjectionTestClass testClass = Container.Resolve<AllArrayInjectionTestClass>();

            Assert.IsNotNull(testClass);
            Assert.IsNotNull(testClass?.sampleTestClasses);
            Assert.IsTrue(testClass?.sampleTestClasses.Length == 3);
        }
        
        private class SampleTestClass
        {

        }
        
        private class OnlyArrayInjectionTestClass
        {
            public readonly SampleTestClass sampleTestClass;
            
            public OnlyArrayInjectionTestClass(SampleTestClass sampleTestClass)
            {
                this.sampleTestClass = sampleTestClass;
            }
        }
        
        private class ArrayFirstInjectionTestClass
        {
            public readonly SampleTestClass[] sampleTestClasses;
            
            public ArrayFirstInjectionTestClass([Inject(ARRAY_FIRST)]SampleTestClass[] sampleTestClasses)
            {
                this.sampleTestClasses = sampleTestClasses;
            }
        }
        
        private class ArraySecondInjectionTestClass
        {
            public readonly SampleTestClass[] sampleTestClasses;
            
            public ArraySecondInjectionTestClass([Inject(ARRAY_SECOND)]SampleTestClass[] sampleTestClasses)
            {
                this.sampleTestClasses = sampleTestClasses;
            }
        }
        
        private class AllArrayInjectionTestClass
        {
            public readonly SampleTestClass[] sampleTestClasses;
            
            public AllArrayInjectionTestClass(SampleTestClass[] sampleTestClasses)
            {
                this.sampleTestClasses = sampleTestClasses;
            }
        }
    }
}