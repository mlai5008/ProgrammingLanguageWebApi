using ProgrammingLanguage.Client.Infrastructure.Enums.Validation;

namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Managers
{
    public interface IValidatorManager
    {
        string TryToValidate(string validationElement, ValidationParameters[] validationParameters);
    }
}