namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs.EventArguments
{
    public interface IDialogCloseRequestedEventArgs
    {
        #region Properties
        bool? DialogResult { get; }
        #endregion
    }
}