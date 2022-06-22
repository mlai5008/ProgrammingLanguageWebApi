using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using ProgrammingLanguage.Client.ApiCommunication;
using ProgrammingLanguage.Client.Infrastructure.Constants;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Services;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views;
using ProgrammingLanguage.Client.Infrastructure.ViewModels.Base;
using System.Windows;

namespace ProgrammingLanguage.Client.ViewModels
{
    public class ShellViewModel : BaseViewModel, IShellViewModel
    {
        #region Fields
        private readonly IModuleManager _moduleManager;
        private readonly IWindowManagementService _windowManagementService;
        #endregion

        #region Properties
        public override string Title => DialogTitleNamesConstants.ProgrammingLanguageClient;
        public bool HasCloseButton { get; set; }
        public bool HasMinimazeButton { get; set; }
        #endregion

        #region ctor
        public ShellViewModel()
        {
            CancelCommand = new DelegateCommand(CancelCommandExecution);
            MinimazeCommand = new DelegateCommand(MinimazeCommandExecution);
            DragWindowCommand = new DelegateCommand(DragWindowCommandExecution);
            HasCloseButton = true;
            HasMinimazeButton = true;
        }

        public ShellViewModel(IRegionManager regionManager,
                              IModuleManager moduleManager,
                              IWindowManagementService windowManagementService) : this()
        {
            _moduleManager = moduleManager;
            _windowManagementService = windowManagementService;

            regionManager.RegisterViewWithRegion(RegionNamesConstants.MainRegion, typeof(IMainView));

            LoadModule();
        }
        #endregion

        #region Commands
        public DelegateCommand CancelCommand { get; }
        public DelegateCommand MinimazeCommand { get; }
        public DelegateCommand DragWindowCommand { get; }
        #endregion

        #region Methods
        private void LoadModule()
        {
            _moduleManager.LoadModule(nameof(ApiCommunicationModule));
        }

        private void CancelCommandExecution()
        {
            Application.Current.Shutdown();
        }

        private void MinimazeCommandExecution()
        {
            _windowManagementService.Minimaze<IShellViewModel>();
        }

        private void DragWindowCommandExecution()
        {
            _windowManagementService.Drag<IShellViewModel>();
        }
        #endregion
    }
}