using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.Services
{
    public interface IWindowManagementService
    {
        #region Methods
        void Minimaze<TViewModel>() where TViewModel : IViewModel;
        void Drag<TViewModel>() where TViewModel : IViewModel;
        #endregion
    }
}