namespace ProgrammingLanguageWebService.Models
{
    public class ProgrammingLanguageModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public byte[] Icon { get; set; } 
        #endregion
    }
}