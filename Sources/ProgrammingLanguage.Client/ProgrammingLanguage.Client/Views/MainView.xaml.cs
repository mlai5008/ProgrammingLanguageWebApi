using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace ProgrammingLanguage.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}