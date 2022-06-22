using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs.EventArguments;
using ProgrammingLanguage.Client.Infrastructure.ViewModels.Base;
using Prism.Commands;
using System;
using System.Windows.Input;

namespace ProgrammingLanguage.Client.ViewModels.Base
{
    public abstract class BaseDialogViewModel<TData> : BaseDialogViewModel, IDialogViewModel<TData> where TData : class
    {
        #region ctor
        public BaseDialogViewModel() : base()
        {

        }
        #endregion

        #region Properties
        private TData _data;

        public TData Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }
        #endregion

        #region Methods
        public virtual void SetData(TData data)
        {
            Data = data;
        }
        #endregion
    }

    public abstract class BaseDialogViewModel : BaseViewModel, IDialogViewModel
    {
        #region ctor
        public BaseDialogViewModel()
        {
            AcceptCommand = new DelegateCommand(Accept, CanExecuteAcceptCommand);
            CancelCommand = new DelegateCommand(Cancel);

            HasACloseButton = true;
        }
        #endregion

        #region Properties
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