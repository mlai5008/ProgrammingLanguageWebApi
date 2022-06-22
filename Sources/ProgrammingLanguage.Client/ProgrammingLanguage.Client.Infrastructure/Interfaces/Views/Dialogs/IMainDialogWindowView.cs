using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Base;
using System.Windows;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Dialogs
{
    public interface IMainDialogWindowView : IDialogView
    {
        #region Properties
        bool? DialogResult { get; set; }

        object Content { get; set; }

        Window Owner { get; set; }
        #endregion

        #region Methods
        bool? ShowDialog();

        void Close();
        #endregion
    }
}