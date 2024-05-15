using Tarject.Runtime.Core.Context;

namespace Tarject.Runtime.Core.Installer
{
    public abstract class ObjectInstallerBase : IInstaller
    {
        public abstract void Install(DIContainer container);
    }
}
