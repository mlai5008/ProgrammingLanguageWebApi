using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Validations;
using ProgrammingLanguage.Client.Infrastructure.Constants;

namespace ProgrammingLanguage.Client.ApiCommunication.Validation
{
    public class EmptyFieldValidator : IEmptyFieldValidator
    {
        #region Methods
        public string TryFieldToValidate(string validationElement)
        {
            return string.IsNullOrEmpty(validationElement) ? MessageConstants.ErrorIfEmptyValidationMessage : null;
        } 
        #endregion
    }
}