using RestSharp;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Clients
{
    public interface IApiClient
    {
        #region Properties
        RestClient RestClient { get; }
        #endregion
    }
}