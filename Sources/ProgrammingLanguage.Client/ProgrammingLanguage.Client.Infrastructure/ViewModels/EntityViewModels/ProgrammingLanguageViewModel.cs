using ProgrammingLanguage.Client.Infrastructure.Interfaces.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel;
using ProgrammingLanguage.Client.Infrastructure.ViewModels.Base;

namespace ProgrammingLanguage.Client.Infrastructure.ViewModels.EntityViewModels
{
    public class ProgrammingLanguageViewModel : BaseViewModel<IProgrammingLanguageModelDto>, IProgrammingLanguageViewModel
    {
        #region Properties
        public override string Title => string.Empty;
        #endregion

        #region WrappersOfProperties
        public int Id
        {
            get => Data.Id;
            set => Data.Id = value;
        }

        public string Name
        {
            get => Data.Name;
            set => Data.Name = value;
        }
        public string FileName
        {
            get => Data.FileName;
            set => Data.FileName = value;
        }

        public string Description
        {
            get => Data.Description;
            set => Data.Description = value;
        }
        
        public byte[] Icon
        {
            get => Data.Icon;
            set => Data.Icon = value;
        }
        #endregion
    }
}