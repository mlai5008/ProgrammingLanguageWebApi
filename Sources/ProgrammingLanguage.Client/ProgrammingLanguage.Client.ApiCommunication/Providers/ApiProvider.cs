using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Providers;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Services;

namespace ProgrammingLanguage.Client.ApiCommunication.Providers
{
    public class ApiProvider : IApiProvider
    {
        #region Fields
        private readonly IProgrammingLanguagesService _programmingLanguagesService;
        #endregion

        #region ctor
        public ApiProvider(IProgrammingLanguagesService programmingLanguagesService)
        {
            _programmingLanguagesService = programmingLanguagesService;
        }
        #endregion

        #region Properties
        public IProgrammingLanguagesService ProgrammingLanguages => _programmingLanguagesService;
        #endregion
    }
}