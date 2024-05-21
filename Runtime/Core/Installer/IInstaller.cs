using Tarject.Runtime.Core.Context;

namespace Tarject.Runtime.Core.Installer
{
    public interface IInstaller
    {
        void Install(DIContainer container);
    }
}