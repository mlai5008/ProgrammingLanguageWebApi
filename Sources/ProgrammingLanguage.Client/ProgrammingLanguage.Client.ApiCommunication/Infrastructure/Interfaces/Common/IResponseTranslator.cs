using ProgrammingLanguage.Client.ApiCommunication.Common;
using RestSharp;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common
{
    public interface IResponseTranslator
    {
        #region Methods
        ApiResponse<T> TranslateResponse<T>(RestResponse<T> restResponse);
        #endregion
    }
}