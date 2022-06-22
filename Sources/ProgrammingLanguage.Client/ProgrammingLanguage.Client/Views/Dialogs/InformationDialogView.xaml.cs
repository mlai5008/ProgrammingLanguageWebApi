using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Dialogs;
using System.Windows.Controls;

namespace ProgrammingLanguage.Client.Views.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для InformationDialogView.xaml
    /// </summary>
    public partial class InformationDialogView : UserControl, IInformationDialogView
    {
        public InformationDialogView()
        {
            InitializeComponent();
        }
    }
}