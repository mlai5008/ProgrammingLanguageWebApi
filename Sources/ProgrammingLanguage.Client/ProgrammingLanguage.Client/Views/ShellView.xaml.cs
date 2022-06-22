using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views;
using System.Windows;

namespace ProgrammingLanguage.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для ShellView.xaml
    /// </summary>
    public partial class ShellView : Window, IShellView
    {
        public ShellView()
        {
            InitializeComponent();
        }
    }
}