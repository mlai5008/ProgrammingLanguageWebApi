using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel
{
    public interface IProgrammingLanguageViewModel : IViewModel
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