using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common;
using RestSharp;

namespace ProgrammingLanguage.Client.ApiCommunication.Common
{
    public class ResponseTranslator : IResponseTranslator
    {
        #region Methods
        public ApiResponse<T> TranslateResponse<T>(RestResponse<T> restResponse)
        {
            return new ApiResponse<T>
            {
                Data = restResponse.Data
            };
        }
        #endregion
    }
}