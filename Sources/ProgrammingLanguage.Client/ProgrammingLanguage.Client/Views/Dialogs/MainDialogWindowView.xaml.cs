using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Dialogs;
using System.Windows;

namespace ProgrammingLanguage.Client.Views.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для MainDialogWindowView.xaml
    /// </summary>
    public partial class MainDialogWindowView : Window, IMainDialogWindowView
    {
        public MainDialogWindowView()
        {
            InitializeComponent();
        }
    }
}