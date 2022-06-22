namespace ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base
{
    public interface IViewModel
    {
        #region Properties
        string Title { get; }
        #endregion
    }

    public interface IViewModel<TData> : IViewModel where TData : class
    {
        #region Properties
        TData Data { get; }
        #endregion

        #region Methods
        void SetData(TData data);
        #endregion
    }
}