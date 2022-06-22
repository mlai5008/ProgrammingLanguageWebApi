using Prism.Commands;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Providers;
using ProgrammingLanguage.Client.Infrastructure.Constants;
using ProgrammingLanguage.Client.Infrastructure.Dialogs;
using ProgrammingLanguage.Client.Infrastructure.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Enums;
using ProgrammingLanguage.Client.Infrastructure.Extensions;
using ProgrammingLanguage.Client.Infrastructure.Helpers;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views;
using ProgrammingLanguage.Client.Infrastructure.ViewModels.Base;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ProgrammingLanguage.Client.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        #region Fields
        private readonly IDialogService _dialogService;
        private readonly IApiProvider _apiProvider;
        private bool _isBusy;
        private string _loadingInformation;
        private ICollectionView _searchableCollection;
        private ObservableCollection<IProgrammingLanguageViewModel> _observedProgrammingLanguages;
        private IProgrammingLanguageViewModel _selectedProgrammingLanguage;
        #endregion

        #region ctor
        public MainViewModel()
        {
            AddProgrammingLanguageCommand = new DelegateCommand(OnAddProgrammingLanguage);
            EditProgrammingLanguageCommand = new DelegateCommand(OnEditProgrammingLanguage, CanSelectedProgrammingLanguage);
            MultiDeleteProgrammingLanguageCommand = new DelegateCommand<object>(async (obj) => await OnMultiDeleteProgrammingLanguage(obj), CanSelectedProgrammingLanguageParam);
        }

        public MainViewModel(IDialogService dialogService, IApiProvider apiProvider) : this()
        {
            _dialogService = dialogService;
            _apiProvider = apiProvider;

            Task.Run(InitializeDataAsync);

            EditProgrammingLanguageCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region Properties
        public override string Title => DialogTitleNamesConstants.ProgrammingLanguageClient;

        public override bool IsBusy
        {
            get => _isBusy;
            protected set => SetProperty(ref _isBusy, value);
        }
        public string LoadingInformation
        {
            get => _loadingInformation;
            set => SetProperty(ref _loadingInformation, value);
        }

        public ObservableCollection<IProgrammingLanguageViewModel> ObservedProgrammingLanguages
        {
            get => _observedProgrammingLanguages;
            set => SetProperty(ref _observedProgrammingLanguages, value);
        }

        public IProgrammingLanguageViewModel SelectedProgrammingLanguage
        {
            get => _selectedProgrammingLanguage;
            set
            {
                if (SetProperty(ref _selectedProgrammingLanguage, value))
                {
                    EditProgrammingLanguageCommand.RaiseCanExecuteChanged();
                    MultiDeleteProgrammingLanguageCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ICollectionView SearchableCollection
        {
            get => _searchableCollection;
            set => SetProperty(ref _searchableCollection, value);
        }
        #endregion

        #region Commands
        public DelegateCommand EditProgrammingLanguageCommand { get; }
        public DelegateCommand AddProgrammingLanguageCommand { get; }
        public DelegateCommand<object> MultiDeleteProgrammingLanguageCommand { get; }
        #endregion

        #region Methods
        private async Task InitializeDataAsync()
        {
            IsBusy = true;

            DisplayLoadingInformation(ControlTitleConstants.GettingDataTitle);

            List<ProgrammingLanguageModelDto> programmingLanguageModelDtos = await _apiProvider.ProgrammingLanguages.GetAll();

            if (programmingLanguageModelDtos == null)
            {
                AppDispatcherHelper.Invoke(() =>
                {
                    IsBusy = false;
                    _dialogService.ShowDialog(DialogType.Error, "No data.");
                    Application.Current.Shutdown();
                });
            }
            else
            {
                IEnumerable<IProgrammingLanguageViewModel>  programmingLanguages = programmingLanguageModelDtos.ToViewModels();

                ObservedProgrammingLanguages = GetObservedProgrammingLanguages(programmingLanguages);

                AppDispatcherHelper.Invoke(() =>
                {
                    SearchableCollection = CollectionViewSource.GetDefaultView(ObservedProgrammingLanguages);

                    AddSortDescriptions();

                    IsBusy = false;
                });
            }
        }

        private ObservableCollection<IProgrammingLanguageViewModel> GetObservedProgrammingLanguages(IEnumerable<IProgrammingLanguageViewModel> programmingLanguages)
        {
            ObservableCollection<IProgrammingLanguageViewModel> programmingLanguagesViewModels = new ObservableCollection<IProgrammingLanguageViewModel>();

            foreach (var breed in programmingLanguages)
            {
                programmingLanguagesViewModels.Add(breed);
            }

            return programmingLanguagesViewModels;
        }

        private void DisplayLoadingInformation(string message)
        {
            AppDispatcherHelper.Invoke(() => { LoadingInformation = message; });
        }

        private void AddSortDescriptions()
        {
            SearchableCollection.SortDescriptions.Add(new SortDescription(nameof(IProgrammingLanguageViewModel.Name), ListSortDirection.Ascending));
        }

        private void RefreshSearchableCollection()
        {
            SearchableCollection.Refresh();
        }

        private void OnAddProgrammingLanguage()
        {
            IEditProgrammingLanguageView editProgrammingLanguageView = ViewExtensions.GetView<IEditProgrammingLanguageView>().SetDataContext();
            IEditProgrammingLanguageViewModel viewModel = (EditProgrammingLanguageViewModel)editProgrammingLanguageView.DataContext;
            viewModel.Initialise(null, false);

            if (_dialogService.ShowDialog(editProgrammingLanguageView))
            {
                Task.Run(InitializeDataAsync);
            }
        }

        private void OnEditProgrammingLanguage()
        {
            IEditProgrammingLanguageView editProgrammingLanguageView = ViewExtensions.GetView<IEditProgrammingLanguageView>().SetDataContext();
            IEditProgrammingLanguageViewModel viewModel = (EditProgrammingLanguageViewModel)editProgrammingLanguageView.DataContext;
            viewModel.Initialise(SelectedProgrammingLanguage, true);

            if (_dialogService.ShowDialog(editProgrammingLanguageView))
            {
                Task.Run(InitializeDataAsync);
            }
        }

        private async Task OnMultiDeleteProgrammingLanguage(object obj)
        {
            if (_dialogService.ShowDialog(Infrastructure.Enums.DialogType.Warning,
                                      MessageConstants.DeleteProgrammingLanguageMessage,
                                      DialogHeaderConstants.WarningScreen,
                                      ControlTitleConstants.OkCTitleUp,
                                      ControlTitleConstants.CancelCTitleUp))
            {
                List<IProgrammingLanguageViewModel> programmingLanguageViewModels = new List<IProgrammingLanguageViewModel>((obj as IList).Cast<IProgrammingLanguageViewModel>());
               IProgrammingLanguageModelDto[] programmingLanguageModelDtos =
                     programmingLanguageViewModels.Select(i => new ProgrammingLanguageModelDto(){Id = i.Id, Name = i.Name, FileName = i.FileName, Description = i.Description, Icon = i.Icon}).Cast<IProgrammingLanguageModelDto>().ToArray();

                await _apiProvider.ProgrammingLanguages.Delete(programmingLanguageModelDtos);
                await InitializeDataAsync();
            }
        }

        private bool CanSelectedProgrammingLanguage()
        {
            return SelectedProgrammingLanguage != null;
        }

        private bool CanSelectedProgrammingLanguageParam(object arg)
        {
            return CanSelectedProgrammingLanguage();
        }
        #endregion
    }
}