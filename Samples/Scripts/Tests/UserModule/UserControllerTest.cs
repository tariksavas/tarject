﻿using NUnit.Framework;
using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services;
using Tarject.Samples.Scripts.Runtime.Signal;
using Tarject.Samples.Scripts.Runtime.UserModule.Controller;
using Tarject.Samples.Scripts.Runtime.UserModule.Model;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.SignalBus.Controller;

namespace Tarject.Samples.Scripts.Tests.UserModule
{
    public class UserControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<UserController>();
            Container.Bind<SignalController>();
            Container.Bind<UserData>();
            Container.Bind<StaticConfigurationService>().ToInterface<IConfigurationService>();
        }

        [Test]
        public void Fetch_User_Data()
        {
            UserController userController = Container.Resolve<UserController>();
            SignalController signalController = Container.Resolve<SignalController>();
            UserData userData = Container.Resolve<UserData>();

            signalController.Subscribe<UserDataReceivedSignal>(Action);
            userController.Initialize();

            void Action(UserDataReceivedSignal signal)
            {
                Assert.IsTrue(signal.UserId == userData.userId);
            }

            Assert.NotNull(userController);
        }
    }
}