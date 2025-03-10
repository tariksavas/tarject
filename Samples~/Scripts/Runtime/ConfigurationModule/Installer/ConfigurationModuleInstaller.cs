using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;

namespace Tarject.Samples.Scripts.Runtime.ConfigurationModule.Installer
{
    public class ConfigurationModuleInstaller : ObjectInstaller<ConfigurationModuleInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<StaticConfigurationService>().ToInterface<IConfigurationService>();
        }
    }
}