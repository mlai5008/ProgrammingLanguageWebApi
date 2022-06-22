using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels
{
    public interface IEditProgrammingLanguageViewModel : IViewModel
    {
        #region Methods
        void Initialise(IProgrammingLanguageViewModel selectedProgrammingLanguage, bool isEditableMode);
        #endregion
    }
}