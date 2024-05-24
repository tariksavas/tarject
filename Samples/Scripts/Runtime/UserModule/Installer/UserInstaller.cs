using Runtime.UserModule.Controller;
using Runtime.UserModule.Model;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;

namespace Runtime.UserModule.Installer
{
    public class UserInstaller : ObjectInstaller<UserInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<UserData>();
            container.Bind<UserController>();
        }
    }
}
