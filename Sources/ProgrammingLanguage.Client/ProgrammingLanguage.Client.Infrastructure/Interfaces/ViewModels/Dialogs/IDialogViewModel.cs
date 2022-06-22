using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs.EventArguments;
using System;
using System.Windows.Input;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs
{
    public interface IDialogViewModel<TData> : IViewModel<TData> where TData : class
    {

    }

    public interface IDialogViewModel : IViewModel
    {
        #region Properties
        bool HasACloseButton { get; set; }
        #endregion

        #region Commands
        ICommand AcceptCommand { get; }

        ICommand CancelCommand { get; }
        #endregion

        #region Events
        event EventHandler<IDialogCloseRequestedEventArgs> CloseRequested;
        #endregion
    }
}