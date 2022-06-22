using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common;
using RestSharp;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ApiCommunication.Common
{
    public class RequestProcessor : IRequestProcessor
    {
        #region Fields
        private readonly IRequestSender _requestSender;
        private readonly IResponseTranslator _responseTranslator;
        #endregion

        #region ctor
        public RequestProcessor(IRequestSender requestSender, IResponseTranslator responseTranslator)
        {
            _requestSender = requestSender;
            _responseTranslator = responseTranslator;
        }
        #endregion

        #region Methods
        public async Task<ApiResponse<T>> ProcessRequestAsync<T>(RestRequest restRequest) where T : new()
        {
            RestResponse<T> restResponse = await _requestSender.SendRequestAsync<T>(restRequest);

            return _responseTranslator.TranslateResponse(restResponse);
        }
        #endregion
    }
}