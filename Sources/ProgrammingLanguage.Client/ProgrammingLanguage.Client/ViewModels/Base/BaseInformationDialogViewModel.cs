using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs.EventArguments;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace ProgrammingLanguage.Client.ViewModels.Base
{
    public abstract class BaseInformationDialogViewModel : BindableBase,  IDialogViewModel
    {
        #region ctor
        public BaseInformationDialogViewModel()
        {
            AcceptCommand = new DelegateCommand(Accept, CanExecuteAcceptCommand);
            CancelCommand = new DelegateCommand(Cancel);

            HasACloseButton = true;
        }
        #endregion

        #region Properties
        public abstract string Title { get; protected set; }
        public abstract string Message { get; protected set; }
        public bool HasACloseButton { get; set; }
        #endregion

        #region Commands
        public ICommand AcceptCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }
        #endregion

        #region Methods
        public virtual bool CanExecuteAcceptCommand()
        {
            return true;
        }

        private void Accept()
        {
            CloseRequest(true);
        }

        private void Cancel()
        {
            CloseRequest(false);
        }

        public void CloseRequest(bool close)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(close));
        }
        #endregion

        #region Events
        public event EventHandler<IDialogCloseRequestedEventArgs> CloseRequested;
        #endregion
    }
}