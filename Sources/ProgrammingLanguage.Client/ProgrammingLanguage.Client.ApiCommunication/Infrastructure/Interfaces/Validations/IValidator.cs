namespace ProgrammingLanguage.Client.ApiCommunication.Infrastructure.Interfaces.Validations
{
    public interface IValidator
    {
        #region Methods
        string TryFieldToValidate(string inputFieldValue); 
        #endregion
    }
}