using ProgrammingLanguage.Client.ApiCommunication.Common;
using RestSharp;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common
{
    public interface IRequestProcessor
    {
        Task<ApiResponse<T>> ProcessRequestAsync<T>(RestRequest restRequest) where T : new();
    }
}