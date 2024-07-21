using Tarject.Samples.Scripts.Runtime.UserModule.Controller;
using Tarject.Samples.Scripts.Runtime.UserModule.Model;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;

namespace Tarject.Samples.Scripts.Runtime.UserModule.Installer
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
