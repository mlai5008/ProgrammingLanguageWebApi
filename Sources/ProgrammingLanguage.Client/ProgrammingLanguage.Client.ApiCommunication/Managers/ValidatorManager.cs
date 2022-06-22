using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Managers;
using ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Validations;
using ProgrammingLanguage.Client.Infrastructure.Enums.Validation;


namespace ProgrammingLanguage.Client.ApiCommunication.Managers
{
    public class ValidatorManager : IValidatorManager
    {
        #region Fields
        private readonly IEmptyFieldValidator _emptyFieldValidator;
        #endregion

        #region ctor
        public ValidatorManager(IEmptyFieldValidator emptyFieldValidator)
        {
            _emptyFieldValidator = emptyFieldValidator;
        }
        #endregion

        #region Methods
        public string TryToValidate(string validationElement, ValidationParameters[] validationParameters)
        {
            string res = null;
            foreach (var validator in validationParameters)
            {
                if (res != null) break;

                switch (validator)
                {
                    case ValidationParameters.EmptyFieldParameter:
                        res = _emptyFieldValidator.TryFieldToValidate(validationElement);
                        break;

                    default:
                        break;
                }
            }

            return res;
        } 
        #endregion
    }
}