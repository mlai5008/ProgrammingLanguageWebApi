using ProgrammingLanguage.Client.Infrastructure.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Services
{
    public interface IProgrammingLanguagesService
    {
        #region Methods
        Task<List<ProgrammingLanguageModelDto>> GetAll();
        Task Post(IProgrammingLanguageModelDto programmingLanguageModelDto);
        Task Put(IProgrammingLanguageModelDto programmingLanguageModelDto);
        Task Delete(IProgrammingLanguageModelDto[] programmingLanguageModelDtos);
        #endregion
    }
}