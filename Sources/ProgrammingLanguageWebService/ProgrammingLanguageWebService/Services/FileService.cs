using Microsoft.AspNetCore.Hosting;
using ProgrammingLanguageWebService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProgrammingLanguageWebService.Services
{
    public class FileService : IFileService
    {
        #region Fields
        private const string Extension = ".png";
        private const string ImagesFolder = "Images";
        private const string JsonFileFolder = "Data";
        private const string JsonFileName = "ProgrammingLanguages.JSON";
        private readonly string _fileJsonPath;
        private readonly string _imagesFolderPath;
        private List<ProgrammingLanguageModel> _programmingLanguageModels;
        #endregion

        #region Ctor
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _fileJsonPath = Path.Combine(webHostEnvironment.ContentRootPath, JsonFileFolder, JsonFileName);

#if DEBUG
            _imagesFolderPath = Path.Combine(webHostEnvironment.ContentRootPath, ImagesFolder);
#endif
#if RELEASE
            string currentDir = Path.GetFullPath(Path.Combine(webHostEnvironment.ContentRootPath, @"..\..\..\..\"));
            _imagesFolderPath = Path.Combine(currentDir, ImagesFolder);
            File.AppendAllLines(@"D:\Result.txt", new string[]{_imagesFolderPath});
#endif
            InitializationData();
        }
        #endregion

        #region Methods
        #region Api Methods
        public List<ProgrammingLanguageModel> GetAll()
        {
            if (_programmingLanguageModels == null || !_programmingLanguageModels.Any())
            {
                return new List<ProgrammingLanguageModel>();
            }
            else
            {
                return _programmingLanguageModels;
            }
        }

        public ProgrammingLanguageModel GetById(int id)
        {
            return _programmingLanguageModels.SingleOrDefault(i => i.Id == id);
        }

        public void AddItem(ProgrammingLanguageModel programmingLanguageModel)
        {
            if (_programmingLanguageModels.Any(i => i.Name.Contains(programmingLanguageModel.Name))) return;
            int id = _programmingLanguageModels.Max(i => i.Id);
            programmingLanguageModel.Id = ++id;
            _programmingLanguageModels.Add(programmingLanguageModel);
            CreateImageFile(programmingLanguageModel);
            WriteToJsonFile(_programmingLanguageModels);
        }

        public void UpdateItem(ProgrammingLanguageModel programmingLanguageModel)
        {
            ProgrammingLanguageModel currentProgrammingLanguageModel = _programmingLanguageModels.Single(i => i.Id == programmingLanguageModel.Id);

            if (!currentProgrammingLanguageModel.Name.Equals(programmingLanguageModel.Name))
            {
                currentProgrammingLanguageModel.Name = programmingLanguageModel.Name;
                UpdateImageFile(currentProgrammingLanguageModel, programmingLanguageModel);
            }
            if (!currentProgrammingLanguageModel.Description.Equals(programmingLanguageModel.Description))
            {
                currentProgrammingLanguageModel.Description = programmingLanguageModel.Description;
            }
            if (!currentProgrammingLanguageModel.Icon.SequenceEqual(programmingLanguageModel.Icon))
            {
                currentProgrammingLanguageModel.Icon = programmingLanguageModel.Icon;
                UpdateImageFile(currentProgrammingLanguageModel, programmingLanguageModel);
            }
        }

        public void DeleteItem(ProgrammingLanguageModel programmingLanguageModel)
        {
            ProgrammingLanguageModel programmingLanguageById = _programmingLanguageModels.Single(i => i.Id == programmingLanguageModel.Id);
            _programmingLanguageModels.Remove(programmingLanguageById);
            DeleteImageFile(programmingLanguageModel);
            WriteToJsonFile(_programmingLanguageModels);
        }
        #endregion

        #region Private methods
        private void InitializationData()
        {
            ReadJsonFile();
            ReadImageFiles();
        }

        private void ReadJsonFile()
        {
            if (!IsExistsFile(_fileJsonPath)) return;
            string jsonString = File.ReadAllText(_fileJsonPath);
            _programmingLanguageModels = JsonSerializer.Deserialize<List<ProgrammingLanguageModel>>(jsonString);
        }

        private void ReadImageFiles()
        {
            string[] filePaths = Directory.GetFiles(_imagesFolderPath, $"*{Extension}");

            foreach (ProgrammingLanguageModel model in _programmingLanguageModels)
            {
                string imagePath = filePaths.Single(f => f.EndsWith(model.FileName));
                if (IsExistsFile(imagePath))
                {
                    model.Icon = System.IO.File.ReadAllBytes(imagePath);
                }
            }
        }

        private void WriteToJsonFile(List<ProgrammingLanguageModel> models)
        {

            List<JsonFileModel> jsonFileModels = models.Select(i => new JsonFileModel(i.Id, i.Name, i.FileName, i.Description)).ToList();
            string jsonString = JsonSerializer.Serialize(jsonFileModels);
            File.WriteAllText(_fileJsonPath, jsonString);
        }

        private void CreateImageFile(ProgrammingLanguageModel programmingLanguageModel)
        {
            string filePath = GetImageFilePathByModel(programmingLanguageModel.FileName);
            File.WriteAllBytes(filePath, programmingLanguageModel?.Icon);
        }

        private void UpdateImageFile(ProgrammingLanguageModel sourceProgrammingLanguageModel, ProgrammingLanguageModel destProgrammingLanguageModel)
        {
            DeleteImageFile(sourceProgrammingLanguageModel);
            CreateImageFile(destProgrammingLanguageModel);
        }

        private void DeleteImageFile(ProgrammingLanguageModel programmingLanguageModel)
        {
            string filePath = GetImageFilePathByModel(programmingLanguageModel.FileName);
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        private string GetImageFilePathByModel(string fileName)
        {
            return Path.Combine(_imagesFolderPath, $"{fileName}");
        }

        private bool IsExistsFile(string filePath)
        {
            return File.Exists(filePath);
        }  
        #endregion
        #endregion
    }
}