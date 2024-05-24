using Runtime.ConfigurationModule.Services;
using Runtime.Signal;
using Runtime.UserModule.Model;
using System.Threading.Tasks;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Core.Interfaces;
using Tarject.Runtime.SignalBus.Controller;

namespace Runtime.UserModule.Controller
{
    public class UserController : IInitializable
    {
        private readonly SignalController _signalController;

        private readonly UserData _userData;

        private readonly IConfigurationService _configurationService;

        [Inject]
        public UserController(SignalController signalController, UserData userData, IConfigurationService configurationService)
        {
            _signalController = signalController;
            _userData = userData;
            _configurationService = configurationService;
        }

        public void Initialize()
        {
            InitializeUserDataAsync();
        }

        private async void InitializeUserDataAsync()
        {
            //Custom delay like in webrequest
            await Task.Delay(500);

            _userData.userId = _configurationService.GetUserIdConfiguration();
            _userData.username = _configurationService.GetUserNameConfiguration();

            _signalController.Fire(new UserDataReceivedSignal(_userData.userId));
        }
    }
}