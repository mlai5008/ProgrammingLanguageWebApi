using ProgrammingLanguage.Client.Infrastructure.Enums;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs
{
    public interface IInformationDialogViewModel : IDialogViewModel
    {
        #region Methods
        void InitializeInformationDialog(DialogType dialogType, string message, string title = null, string acceptButtonTitle = null, string cancelButtonTitle = null, DialogWindowStyle dialogWindowStyle = DialogWindowStyle.WithCloseButton);
        #endregion
    }
}