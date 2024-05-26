using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.SignalBus.Controller;

namespace Tarject.Tests.Editor.SignalBus
{
    public class SignalControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<SignalController>();
        }

        [Test]
        public void Subscribe()
        {
            SignalController signalController = Container.Resolve<SignalController>();
            signalController.Subscribe<TestSignal>(Action);

            void Action(TestSignal _) { }

            Assert.IsTrue(signalController.Exists<TestSignal>(Action));
        }

        [Test]
        public void Unsubscribe()
        {
            SignalController signalController = Container.Resolve<SignalController>();
            signalController.Subscribe<TestSignal>(Action);
            signalController.Unsubscribe<TestSignal>(Action);

            void Action(TestSignal _) { }

            Assert.IsFalse(signalController.Exists<TestSignal>(Action));
        }
                        
        private readonly struct TestSignal
        {
        }
    }
}