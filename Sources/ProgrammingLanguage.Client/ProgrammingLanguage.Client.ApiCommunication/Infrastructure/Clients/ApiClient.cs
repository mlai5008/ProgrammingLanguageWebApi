using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Clients;
using RestSharp;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Clients
{
    public class ApiClient : IApiClient
    {
        #region Constants
        private const string BaseUri = "http://localhost:5000/ProgrammingLanguage";
        #endregion

        #region Propperties
        private RestClient _restClient;
        #endregion

        #region ctor
        public ApiClient()
        {
            CreateRestClient();
        }
        #endregion

        #region Properties
        public RestClient RestClient => _restClient;
        #endregion

        #region Methods
        private void CreateRestClient()
        {
            _restClient = new RestClient(BaseUri);
        }
        #endregion
    }
}