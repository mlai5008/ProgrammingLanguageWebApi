using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Clients;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common;
using RestSharp;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ApiCommunication.Common
{
    public class RequestSender : IRequestSender
    {
        #region Fields
        private readonly RestClient _restClient;
        #endregion

        #region ctor
        public RequestSender(IApiClient catApiClient)
        {
            _restClient = catApiClient.RestClient;
        }
        #endregion

        #region Methods
        public async Task<RestResponse<T>> SendRequestAsync<T>(RestRequest restRequest) where T : new()
        {
            return await _restClient.ExecuteAsync<T>(restRequest);
        }
        #endregion
    }
}