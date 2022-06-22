using ProgrammingLanguageWebService.Models;
using System.Collections.Generic;

namespace ProgrammingLanguageWebService.Services
{
    public interface IFileService
    {
        #region Methods
        public List<ProgrammingLanguageModel> GetAll();
        public ProgrammingLanguageModel GetById(int id);
        public void AddItem(ProgrammingLanguageModel programmingLanguageModel);
        public void UpdateItem(ProgrammingLanguageModel programmingLanguageModel);
        public void DeleteItem(ProgrammingLanguageModel programmingLanguageModel); 
        #endregion
    }
}