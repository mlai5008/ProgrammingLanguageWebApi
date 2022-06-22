using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace ProgrammingLanguage.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProgrammingLanguageView.xaml
    /// </summary>
    public partial class EditProgrammingLanguageView : UserControl, IEditProgrammingLanguageView
    {
        public EditProgrammingLanguageView()
        {
            InitializeComponent();
        }
    }
}