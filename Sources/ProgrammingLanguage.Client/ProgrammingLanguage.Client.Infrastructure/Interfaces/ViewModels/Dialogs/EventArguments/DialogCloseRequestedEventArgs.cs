using System;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs.EventArguments
{
    public class DialogCloseRequestedEventArgs : EventArgs, IDialogCloseRequestedEventArgs
    {
        #region ctor
        public DialogCloseRequestedEventArgs(bool? dialogResult)
        {
            DialogResult = dialogResult;
        }
        #endregion

        #region Properties
        public bool? DialogResult { get; protected set; }
        #endregion
    }
}