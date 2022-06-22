using ProgrammingLanguage.Client.Infrastructure.Enums;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs;
using ProgrammingLanguage.Client.ViewModels.Base;

namespace ProgrammingLanguage.Client.ViewModels.Dialogs
{
    public class InformationDialogViewModel : BaseInformationDialogViewModel, IInformationDialogViewModel
    {
        #region Fields
        private DialogType _dialogType;
        private DialogWindowStyle _dialogWindowStyle;
        #endregion

        #region Properties
        public override string Title { get; protected set; }
        public override string Message { get; protected set; }
        public string AcceptButtonTitle { get; private set; }
        public string CancelButtonTitle { get; private set; }
        public bool IsWarningDialogType { get; set; }
        #endregion

        #region Methods
        public void InitializeInformationDialog(DialogType dialogType, string message, string title = null, string acceptButtonTitle = null, string cancelButtonTitle = null, DialogWindowStyle dialogWindowStyle = DialogWindowStyle.WithCloseButton)
        {
            _dialogType = dialogType;
            _dialogWindowStyle = dialogWindowStyle;

            Message = message;
            Title = title ?? dialogType.ToString();
            AcceptButtonTitle = acceptButtonTitle;
            CancelButtonTitle = cancelButtonTitle;

            Initialize();
        }

        private void Initialize()
        {
            switch (_dialogType)
            {
                case DialogType.Information:
                case DialogType.Error:
                    IsWarningDialogType = false;
                    break;
                case DialogType.Warning:
                    IsWarningDialogType = true;
                    break;
            }

            switch (_dialogWindowStyle)
            {
                case DialogWindowStyle.WithCloseButton:
                    HasACloseButton = true;
                    break;
                case DialogWindowStyle.WithoutCloseButton:
                    HasACloseButton = false;
                    break;
            }
        }
        #endregion
    }
}