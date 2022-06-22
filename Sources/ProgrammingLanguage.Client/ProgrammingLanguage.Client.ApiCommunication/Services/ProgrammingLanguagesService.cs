using ProgrammingLanguage.Client.ApiCommunication.Common;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Common;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Services;
using ProgrammingLanguage.Client.Infrastructure.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.DtoModels;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ApiCommunication.Services
{
    internal class ProgrammingLanguagesService : IProgrammingLanguagesService
    {
        #region Fields
        private readonly IRequestProcessor _requestProcessor;
        #endregion

        #region ctor
        public ProgrammingLanguagesService(IRequestProcessor requestProcessor)
        {
            _requestProcessor = requestProcessor;
        }
        #endregion

        #region Methods
        public async Task<List<ProgrammingLanguageModelDto>> GetAll()
        {
            RestRequest restRequest = CreateGetAllRestRequest();

            ApiResponse<List<ProgrammingLanguageModelDto>> apiResponse = await _requestProcessor.ProcessRequestAsync<List<ProgrammingLanguageModelDto>>(restRequest);

            return apiResponse.Data;
        }

        public async Task Post(IProgrammingLanguageModelDto programmingLanguageModelDto)
        {
            RestRequest restRequest = CreatePostRestRequest(programmingLanguageModelDto);

            await _requestProcessor.ProcessRequestAsync<ProgrammingLanguageModelDto>(restRequest);
        }

        public async Task Put(IProgrammingLanguageModelDto programmingLanguageModelDto)
        {
            RestRequest restRequest = CreatePutRestRequest(programmingLanguageModelDto);

            await _requestProcessor.ProcessRequestAsync<ProgrammingLanguageModelDto>(restRequest);
        }

        public async Task Delete(IProgrammingLanguageModelDto[] programmingLanguageModelDtos)
        {
            RestRequest restRequest = CreateDeleteRestRequest(programmingLanguageModelDtos);

            await _requestProcessor.ProcessRequestAsync<ProgrammingLanguageModelDto>(restRequest);
        }

        private RestRequest CreateGetAllRestRequest()
        {
            return new RestRequest(string.Empty, Method.Get);
        }

        private RestRequest CreatePostRestRequest(IProgrammingLanguageModelDto programmingLanguageModelDto)
        {
            return new RestRequest(string.Empty, Method.Post)
                .AddBody(GetModelDto(programmingLanguageModelDto));
        }

        private RestRequest CreatePutRestRequest(IProgrammingLanguageModelDto programmingLanguageModelDto)
        {
            return new RestRequest(string.Empty, Method.Put)
                .AddBody(GetModelDto(programmingLanguageModelDto));
        }

        private RestRequest CreateDeleteRestRequest(IProgrammingLanguageModelDto[] programmingLanguageModelArray)
        {
            ProgrammingLanguageModelDto[] programmingLanguageModelDtos = new ProgrammingLanguageModelDto[programmingLanguageModelArray.Length];
            for (int i = 0; i < programmingLanguageModelDtos.Length; i++)
            {
                programmingLanguageModelDtos[i] = GetModelDto(programmingLanguageModelArray[i]);
            }

            return new RestRequest(string.Empty, Method.Delete)
                .AddBody(programmingLanguageModelDtos);
        }

        private ProgrammingLanguageModelDto GetModelDto(IProgrammingLanguageModelDto programmingLanguageModelDto)
        {
            return new ProgrammingLanguageModelDto()
            {
                Id = programmingLanguageModelDto.Id,
                Name = programmingLanguageModelDto.Name,
                FileName = programmingLanguageModelDto.FileName,
                Description = programmingLanguageModelDto.Description,
                Icon = programmingLanguageModelDto.Icon
            };
        }
        #endregion
    }
}