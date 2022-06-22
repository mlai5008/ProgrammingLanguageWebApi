using ProgrammingLanguage.Client.Infrastructure.Enums;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Base;

namespace ProgrammingLanguage.Client.Infrastructure.Dialogs
{
    public interface IDialogService
    {
        #region Methods
        bool ShowDialog<TView>(TView dialogView) where TView : IView;

        bool ShowDialog(DialogType dialogType, string message, string title = null, string acceptButtonTitle = null, string cancelButtonTitle = null, DialogWindowStyle dialogWindowStyle = DialogWindowStyle.WithCloseButton);
        #endregion
    }
}