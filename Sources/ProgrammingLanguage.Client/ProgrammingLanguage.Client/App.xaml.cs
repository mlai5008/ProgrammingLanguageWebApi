using ProgrammingLanguage.Client.Infrastructure.Constants;
using ProgrammingLanguage.Client.Infrastructure.Dialogs;
using ProgrammingLanguage.Client.Infrastructure.Enums;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Services;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Dialogs;
using ProgrammingLanguage.Client.ViewModels;
using ProgrammingLanguage.Client.ViewModels.Dialogs;
using ProgrammingLanguage.Client.Views;
using ProgrammingLanguage.Client.Views.Dialogs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;
using System.Windows.Threading;
using ProgrammingLanguage.Client.ApiCommunication;
using ProgrammingLanguage.Client.Services;
using ProgrammingLanguage.Client.Infrastructure.ViewModels.EntityViewModels;

namespace ProgrammingLanguage.Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Fields
        private IContainerRegistry _containerRegistry;
        private IDialogService _dialogService;
        #endregion

        #region OverrideMethods
        protected override Window CreateShell()
        {
            var shell = Container.Resolve<IShellView>();
            return (ShellView)shell;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;

            RegisterViews();
            RegisterViewModels();
            RegisterServices();
            ConfigureEntityViewModels();
            RegisterDialogService();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ApiCommunicationModule>();
        }
        #endregion

        #region Methods
        private void RegisterServices()
        {
            _containerRegistry.RegisterSingleton<IWindowManagementService, WindowManagementService>();
        }

        private void RegisterViewModels()
        {
            _containerRegistry.RegisterSingleton<IShellViewModel, ShellViewModel>();
            _containerRegistry.RegisterSingleton<IMainViewModel, MainViewModel>();
            _containerRegistry.Register<IEditProgrammingLanguageViewModel, EditProgrammingLanguageViewModel>();
        }

        private void RegisterViews()
        {
            _containerRegistry.RegisterSingleton<IShellView, ShellView>();
            _containerRegistry.RegisterSingleton<IMainView, MainView>();
            _containerRegistry.Register<IEditProgrammingLanguageView, EditProgrammingLanguageView>();
        }

        private void ConfigureEntityViewModels()
        {
            _containerRegistry.Register<IProgrammingLanguageViewModel, ProgrammingLanguageViewModel>();
        }

        private void RegisterDialogService()
        {
            _containerRegistry.RegisterSingleton<IDialogService, DialogService>();
            _containerRegistry.Register<IMainDialogWindowView, MainDialogWindowView>();
            _containerRegistry.Register<IInformationDialogViewModel, InformationDialogViewModel>();
            _containerRegistry.Register<IInformationDialogView, InformationDialogView>();

        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            HandleException(e.Exception);
        }

        private void HandleException(Exception e)
        {
            string message = e.InnerException != null ? e.InnerException.Message : e.Message;

            try
            {
                _dialogService = Container.Resolve<IDialogService>();
                _dialogService?.ShowDialog(DialogType.Error, message, DialogHeaderConstants.ErrorScreen);
            }
            catch
            {
                EmergencyExitFromApplication();
            }
        }

        private void EmergencyExitFromApplication()
        {
            Environment.Exit(-1);
        }
        #endregion
    }
}