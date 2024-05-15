using Tarject.Runtime.Core.Context;
using UnityEngine;

namespace Tarject.Runtime.Core.Installer
{
    public abstract class GameObjectInstallerBase : MonoBehaviour, IInstaller
    {
        public abstract void Install(DIContainer container);
    }
}
