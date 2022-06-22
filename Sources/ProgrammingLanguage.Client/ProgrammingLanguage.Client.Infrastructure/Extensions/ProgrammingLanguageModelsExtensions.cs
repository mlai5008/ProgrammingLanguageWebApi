using ProgrammingLanguage.Client.Infrastructure.DtoModels;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.EntityViewModel;
using ProgrammingLanguage.Client.Infrastructure.ViewModels.EntityViewModels;
using System.Collections.Generic;

namespace ProgrammingLanguage.Client.Infrastructure.Extensions
{
    public static class ProgrammingLanguageModelsExtensions
    {
        #region Methods
        public static List<IProgrammingLanguageViewModel> ToViewModels(this List<ProgrammingLanguageModelDto> programmingLanguageDtos)
        {
            List<IProgrammingLanguageViewModel> programmingLanguageViewModels = new List<IProgrammingLanguageViewModel>();

            foreach (var programmingLanguage in programmingLanguageDtos)
            {
                programmingLanguageViewModels.Add(new ProgrammingLanguageViewModel { Data = programmingLanguage });
            }

            return programmingLanguageViewModels;
        }
        #endregion
    }
}