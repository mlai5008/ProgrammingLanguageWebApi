using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleRestClient
{
    class Program
    {
        private static RestClient _restClient;

        static void Main()
        {
            //_restClient = new RestClient(new Uri("http://localhost:5008/ProgrammingLanguage"));
            //_restClient = new RestClient(new Uri("http://localhost:5000/ProgrammingLanguage"));
            _restClient = new RestClient(new Uri("https://localhost:44386/ProgrammingLanguage"));
            //restClient.AddDefaultHeader("Content-Type", "application/json");
            //restClient.AddDefaultHeader("Accept", "/");

            //GetAll();
            Console.WriteLine();
            //GetWithId();
            //Post();
            //Put();
            Delete();

            Console.ReadKey();
        }

        static void GetAll()
        {
            RestRequest request = new RestRequest(string.Empty, Method.Get);

            RestResponse<List<ProgrammingLanguageModelDto>> response = _restClient.Execute<List<ProgrammingLanguageModelDto>>(request);
            if (response.IsSuccessful)
            {
                List<ProgrammingLanguageModelDto> dto = response.Data;
                foreach (ProgrammingLanguageModelDto modeDto in dto)
                {
                    Console.WriteLine(modeDto);
                }
            }
        }
        static void GetWithId()
        {
            RestRequest request = new RestRequest("/2", Method.Get);

            RestResponse<ProgrammingLanguageModelDto> response = _restClient.Execute<ProgrammingLanguageModelDto>(request);
            if (response.IsSuccessful)
            {
                ProgrammingLanguageModelDto dto = response.Data;
                Console.WriteLine(dto);
            }
        }

        static void Post()
        {
            string pathFolder = @"D:\_DailyWork\Наработки\100_Home\Для собесед\1001_Тестовое\Images\2";
            string[] filePaths = Directory.GetFiles(pathFolder, $"*.png");
            string path = filePaths[0];
            RestRequest request = new RestRequest();
            request.AddBody(new ProgrammingLanguageModelDto()
            {
                Name = Path.GetFileName(path),
                Description = "New Language",
                Icon = File.ReadAllBytes(path),
            });

            RestResponse<ProgrammingLanguageModelDto> response = _restClient.Execute<ProgrammingLanguageModelDto>(request, Method.Post);
            if (response.IsSuccessful)
            {
                //ProgrammingLanguageModeDto dto = response.Data;
                //File.WriteAllBytes("Icon.PNG", dto?.Icon);
                //return await _restClient.ExecuteAsync<T>(restRequest);
            }
        }

        static void Put()
        {
            string pathFolder = @"D:\_DailyWork\Наработки\100_Home\Для собесед\1001_Тестовое\Images\2";
            string[] filePaths = Directory.GetFiles(pathFolder, $"*.png");
            string path = filePaths[0];
            RestRequest request = new RestRequest();
            request.AddBody(new ProgrammingLanguageModelDto()
            {
                Id = 8,
                Name = Path.GetFileName(path),
                Description = "New Language 222",
                Icon = File.ReadAllBytes(path),
            });
            RestResponse<ProgrammingLanguageModelDto> response = _restClient.Execute<ProgrammingLanguageModelDto>(request, Method.Put);
            if (response.IsSuccessful)
            {
                
            }
        }

        static void Delete()
        {
            //string pathFolder = @"D:\_DailyWork\Наработки\100_Home\Для собесед\1001_Тестовое\Images\2";
            //string[] filePaths = Directory.GetFiles(pathFolder, $"*.png");
            //string path = filePaths[0];
            //RestRequest request = new RestRequest(String.Empty, Method.Delete);
            //request.AddBody(new ProgrammingLanguageModelDto()
            //{
            //    Id = 8,
            //    Name = Path.GetFileName(path),
            //    Description = "New Language",
            //    Icon = File.ReadAllBytes(path),
            //});

            //RestResponse response = _restClient.Execute(request);
            //if (response.IsSuccessful)
            //{

            //}

            string pathFolder = @"D:\_DailyWork\Наработки\100_Home\Для собесед\1001_Тестовое\Images\2";
            string[] filePaths = Directory.GetFiles(pathFolder, $"*.png");
            string path = filePaths[0];
            RestRequest request = new RestRequest(String.Empty, Method.Delete);
            request.AddBody(new ProgrammingLanguageModelDto[] {new ProgrammingLanguageModelDto()
            {
                Id = 8,
                Name = Path.GetFileName(path),
                Description = "New Language",
                Icon = File.ReadAllBytes(path),
            },
                new ProgrammingLanguageModelDto()
                {
                    Id = 9,
                    Description = "4rerrgt"
                }, 
            });

            RestResponse response = _restClient.Execute(request);
            if (response.IsSuccessful)
            {

            }
        }
    }

    public class ProgrammingLanguageModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Icon { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}\nName:{Name}\nDescription:{Description}\nIcon:{Icon.Length} Length";
        }
    }
}
