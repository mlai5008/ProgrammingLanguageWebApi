namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.DtoModels
{
    public interface IProgrammingLanguageModelDto
    {
        #region Properties
        int Id { get; set; }
        string Name { get; set; }
        string FileName { get; set; }
        string Description { get; set; }
        byte[] Icon { get; set; }
        #endregion
    }
}