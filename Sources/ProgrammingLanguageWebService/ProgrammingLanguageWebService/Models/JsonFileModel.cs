namespace ProgrammingLanguageWebService.Models
{
    public class JsonFileModel
    {
        #region Ctor
        public JsonFileModel(int id, string name, string fileName, string description)
        {
            Id = id;
            Name = name;
            FileName = fileName;
            Description = description;
        } 
        #endregion

        #region Properties
        public int Id { get; }
        public string Name { get; }
        public string FileName { get; }
        public string Description { get; } 
        #endregion
    }
}