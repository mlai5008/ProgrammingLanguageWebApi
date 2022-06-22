using ProgrammingLanguage.Client.Infrastructure.Constants;
using ProgrammingLanguage.Client.Infrastructure.Enums;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Dialogs.EventArguments;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Base;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Dialogs;
using Prism.Ioc;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Effects;

namespace ProgrammingLanguage.Client.Infrastructure.Dialogs
{
    public class DialogService : IDialogService
    {
        #region Fields
        private readonly IContainerProvider _container;
        #endregion

        #region ctor
        public DialogService(IContainerProvider container)
        {
            _container = container;
        }
        #endregion

        #region Methods
        public bool ShowDialog<TView>(TView dialogView) where TView : IView
        {
            IMainDialogWindowView ownerView = _container.Resolve<IMainDialogWindowView>();

            InitializeDialogCloseRequestHandler(ownerView, (IDialogViewModel)dialogView.DataContext);
            SetDialogOwner(ownerView);

            ownerView.Content = dialogView;
            ownerView.DataContext = dialogView.DataContext;

            ApplyEffect(ownerView);

            return (bool)ownerView.ShowDialog();
        }

        public bool ShowDialog(DialogType dialogType, string message, string title = null, string acceptButtonTitle = null, string cancelButtonTitle = null, DialogWindowStyle dialogWindowStyle = DialogWindowStyle.WithCloseButton)
        {
            IMainDialogWindowView ownerView = _container.Resolve<IMainDialogWindowView>();
            IInformationDialogView informationDialogView = _container.Resolve<IInformationDialogView>();
            IInformationDialogViewModel informationDialogViewModel = _container.Resolve<IInformationDialogViewModel>();
            informationDialogViewModel.InitializeInformationDialog(dialogType, message, title, acceptButtonTitle ?? ControlTitleConstants.OkCTitleUp,
                                                                   cancelButtonTitle ?? ControlTitleConstants.CancelCTitleUp, dialogWindowStyle);

            informationDialogView.DataContext = informationDialogViewModel;

            InitializeDialogCloseRequestHandler(ownerView, informationDialogViewModel);
            SetDialogOwner(ownerView);

            ownerView.Content = informationDialogView;
            ownerView.DataContext = informationDialogView.DataContext;

            ApplyEffect(ownerView);

            return (bool)ownerView.ShowDialog();
        }

        private void InitializeDialogCloseRequestHandler(IMainDialogWindowView ownerView, IDialogViewModel viewModel)
        {
            EventHandler<IDialogCloseRequestedEventArgs> handler = null;

            handler = (sender, e) => {
                viewModel.CloseRequested -= handler;

                if (e.DialogResult.HasValue)
                {
                    ClearEffect(ownerView);
                    ownerView.DialogResult = e.DialogResult;
                }
                else
                {
                    ClearEffect(ownerView);
                    ownerView.Close();
                }
            };

            viewModel.CloseRequested += handler;
        }

        private void SetDialogOwner(IMainDialogWindowView ownerView)
        {
            ownerView.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        }

        private void ApplyEffect(IMainDialogWindowView view)
        {
            if (view.Owner != null)
            {
                BlurEffect objBlur = new BlurEffect { Radius = 12 };
                view.Owner.Effect = objBlur;
            }
        }

        private void ClearEffect(IMainDialogWindowView view)
        {
            if (view.Owner != null) view.Owner.Effect = null;
        }
        #endregion
    }
}