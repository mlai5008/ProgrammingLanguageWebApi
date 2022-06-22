using Microsoft.Win32;
using Prism.Commands;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Managers;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Providers;
using ProgrammingLanguage.Client.Infrastructure.Constants;
using ProgrammingLanguage.Client.Infrastructure.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Enums.Validation;
using ProgrammingLanguage.Client.Infrastructure.Helpers;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel;
using ProgrammingLanguage.Client.ViewModels.Base;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Client.ViewModels
{
    public class EditProgrammingLanguageViewModel : BaseDialogViewModel, IEditProgrammingLanguageViewModel
    {
        #region Constants
        private const string FilesFilter = "Image files (*.png) | *.png;";
        private const string ImagesFolder = "Images";
        #endregion

        #region Fields
        private bool _isBusy;
        private IProgrammingLanguageViewModel _selectedProgrammingLanguage;
        private readonly IApiProvider _apiProvider;
        private readonly IValidatorManager _validatorManager;
        private int _id;
        private string _name;
        private string _fileName;
        private string _description;
        private byte[] _icon;
        private bool _isEditableMode;
        private bool _hasPossibleValid;
        private string _validationHint;
        #endregion

        #region ctor
        public EditProgrammingLanguageViewModel()
        {
            SaveCommand = new DelegateCommand(Save, CanSave);
            EditPhotoCommand = new DelegateCommand(EditPhoto);
        }

        public EditProgrammingLanguageViewModel(IApiProvider apiProvider, IValidatorManager validatorManager) : this()
        {
            _apiProvider = apiProvider;
            _validatorManager = validatorManager;
        }
        #endregion

        #region Properties
        public override string Title => _isEditableMode ? DialogHeaderConstants.EditProgrammingLanguage : DialogHeaderConstants.AddProgrammingLanguage;

        public override bool IsBusy
        {
            get => _isBusy;
            protected set => SetProperty(ref _isBusy, value);
        }

        public IProgrammingLanguageViewModel SelectedProgrammingLanguage
        {
            get => _selectedProgrammingLanguage;
            set => SetProperty(ref _selectedProgrammingLanguage, value);
        }

        public bool HasPossibleValid
        {
            get => _hasPossibleValid;
            set => SetProperty(ref _hasPossibleValid, value);
        }

        public string ValidationHint
        {
            get => _validationHint;
            set => SetProperty(ref _validationHint, value);
        }

        #region Wrappers
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set
            {
                if (SetProperty(ref _name, value)) CommandsRaiseCanExecuteChanged();
            }
        }

        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        public string Description
        {
            get => _description;
            set
            {
                if (SetProperty(ref _description, value)) CommandsRaiseCanExecuteChanged();
            }
        }

        public byte[] Icon
        {
            get => _icon;
            set
            {
                if (SetProperty(ref _icon, value)) CommandsRaiseCanExecuteChanged();
            }
        }

        #endregion
        #endregion

        #region Commands
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand EditPhotoCommand { get; }
        #endregion

        #region Methods
        public void Initialise(IProgrammingLanguageViewModel selectedProgrammingLanguage, bool isEditableMode)
        {
            _isEditableMode = isEditableMode;

            IsBusy = true;

            SelectedProgrammingLanguage = selectedProgrammingLanguage;

            if (isEditableMode)
            {
                Name = SelectedProgrammingLanguage.Name;
                FileName = SelectedProgrammingLanguage.FileName;
                Description = SelectedProgrammingLanguage.Description;
                Icon = SelectedProgrammingLanguage.Icon;
            }

            IsBusy = false;

            CommandsRaiseCanExecuteChanged();
        }

        private void Save()
        {
            IsBusy = true;

            if (_isEditableMode)
            {
                IProgrammingLanguageModelDto programmingLanguage = new ProgrammingLanguageModelDto()
                {
                    Id = SelectedProgrammingLanguage.Id,
                    Name = Name,
                    FileName = FileName,
                    Description = Description,
                    Icon = Icon
                };

                Task.Run(async () =>
                {
                    await _apiProvider.ProgrammingLanguages.Put(programmingLanguage);

                    AppDispatcherHelper.Invoke(() =>
                    {
                        IsBusy = false;
                        CloseRequest(true);
                    });
                });
            }
            else
            {
                IProgrammingLanguageModelDto programmingLanguage = new ProgrammingLanguageModelDto()
                {
                    Name = Name,
                    FileName = FileName,
                    Description = Description,
                    Icon = Icon
                };

                Task.Run(async () =>
                {
                    await _apiProvider.ProgrammingLanguages.Post(programmingLanguage);

                    AppDispatcherHelper.Invoke(() =>
                    {
                        IsBusy = false;
                        CloseRequest(true);
                    });
                });
            }
        }

        private void EditPhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = FilesFilter,
                Title = DialogHeaderConstants.SelectImageFileScreen,
                InitialDirectory = Path.Combine(Environment.CurrentDirectory, ImagesFolder)
            };

            if (openFileDialog.ShowDialog() != true) return;
            
            string photoPath = openFileDialog.FileName;
            Icon = File.ReadAllBytes(photoPath);
            FileName = Path.GetFileName(photoPath);
        }

        private bool CanSave()
        {
            if (IsBusy) return !IsBusy;

            if (_isEditableMode)
            {
                return !HasErrors && IsWrapperElementDifferOrigin();
            }
            else
            {
                return !HasErrors && HasPossibleValid && Icon != null && Icon.Any();
            }
        }

        private bool IsWrapperElementDifferOrigin()
        {
            return !Equals(SelectedProgrammingLanguage?.Name, Name) ||
                   !Equals(SelectedProgrammingLanguage?.Description, Description) ||
                   !Equals(SelectedProgrammingLanguage?.Icon, Icon);
        }

        private void CommandsRaiseCanExecuteChanged()
        {
            SaveCommand?.RaiseCanExecuteChanged();
        }
        #endregion

        #region Validation
        public override string this[string propName]
        {
            get
            {
                string result = null;
                ValidationParameters[] validationNameParameters = { ValidationParameters.EmptyFieldParameter };

                switch (propName)
                {
                    case nameof(Name):
                        if (Name is null) return null;
                        HasPossibleValid = true;
                        ClearErrors(propName);
                        result = _validatorManager.TryToValidate(Name, validationNameParameters);
                        break;
                    default:
                        ClearErrors(propName);
                        break;
                }

                AddErrorToCollection(propName, result);

                CommandsRaiseCanExecuteChanged();

                ValidationHint = !string.IsNullOrEmpty(result) ? result : string.Empty;

                return result;
            }
        } 
        #endregion
    }
}