using System.Windows;

namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Base
{
    public interface IMainView
    {
        #region Properties
        WindowState WindowState { get; set; }

        object DataContext { get; set; }
        #endregion

        #region Methods
        void DragMove();
        #endregion
    }
}