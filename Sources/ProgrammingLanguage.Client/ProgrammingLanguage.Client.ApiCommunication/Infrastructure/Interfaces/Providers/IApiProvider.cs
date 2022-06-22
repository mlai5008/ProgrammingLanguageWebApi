using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Services;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Providers
{
    public interface IApiProvider
    {
        #region Properties
        IProgrammingLanguagesService ProgrammingLanguages { get; }
        #endregion
    }
}