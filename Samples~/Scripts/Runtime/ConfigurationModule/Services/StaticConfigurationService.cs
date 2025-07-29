using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Config;

namespace Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services
{
    public class StaticConfigurationService : IConfigurationService
    {
        public string GetUserIdConfiguration()
        {
            return UserConfigs.USER_ID;
        }

        public string GetUserNameConfiguration()
        {
            return UserConfigs.USER_NAME;
        }
    }
}