using RestSharp;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common
{
    public interface IRequestSender
    {
        #region Methods
        Task<RestResponse<T>> SendRequestAsync<T>(RestRequest restRequest) where T : new();
        #endregion
    }
}