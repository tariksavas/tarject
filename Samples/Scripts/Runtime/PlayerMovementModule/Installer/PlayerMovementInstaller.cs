using Tarject.Samples.Scripts.Runtime.PlayerMovementModule.Controller;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;

namespace Tarject.Samples.Scripts.Runtime.PlayerMovementModule.Installer
{
    public class PlayerMovementInstaller : ObjectInstaller<PlayerMovementInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.BindFromHierarchy<InputHandler>();
            container.Bind<PlayerMovementController>();
        }
    }
}