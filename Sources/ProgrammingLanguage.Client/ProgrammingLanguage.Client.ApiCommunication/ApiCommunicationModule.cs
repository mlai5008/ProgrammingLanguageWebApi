using Prism.Ioc;
using Prism.Modularity;
using ProgrammingLanguage.Client.ApiCommunication.Common;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Clients;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Clients;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Managers;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Providers;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Services;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Validations;
using ProgrammingLanguage.Client.ApiCommunication.Managers;
using ProgrammingLanguage.Client.ApiCommunication.Providers;
using ProgrammingLanguage.Client.ApiCommunication.Services;
using ProgrammingLanguage.Client.ApiCommunication.Validation;

namespace ProgrammingLanguage.Client.ApiCommunication
{
    public class ApiCommunicationModule : IModule
    {
        #region Fields
        private IContainerRegistry _containerRegistry;
        #endregion

        #region Methods
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;

            RegisterClients();
            RegisterClientServices();
            RegisterCommonServices();
            RegisterProviders();
            RegisterManagers();
        }

        private void RegisterClients()
        {
            _containerRegistry.RegisterSingleton<IApiClient, ApiClient>();
        }
        private void RegisterCommonServices()
        {
            _containerRegistry.RegisterSingleton<IRequestProcessor, RequestProcessor>();
            _containerRegistry.RegisterSingleton<IRequestSender, RequestSender>();
            _containerRegistry.RegisterSingleton<IResponseTranslator, ResponseTranslator>();
        }

        private void RegisterClientServices()
        {
            _containerRegistry.RegisterSingleton<IProgrammingLanguagesService, ProgrammingLanguagesService>();
        }

        private void RegisterProviders()
        {
            _containerRegistry.RegisterSingleton<IApiProvider, ApiProvider>();
        }

        private void RegisterManagers()
        {
            _containerRegistry.RegisterSingleton<IValidatorManager, ValidatorManager>();
            _containerRegistry.RegisterSingleton<IEmptyFieldValidator, EmptyFieldValidator>();
        }
        #endregion
    }
}