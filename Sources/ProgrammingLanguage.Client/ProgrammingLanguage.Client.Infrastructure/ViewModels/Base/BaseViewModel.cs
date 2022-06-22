using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base;
using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ProgrammingLanguage.Client.Infrastructure.ViewModels.Base
{
    public abstract class BaseViewModel<TData> : BaseViewModel, IViewModel<TData> where TData : class
    {
        #region ctor
        public BaseViewModel() : base()
        {

        }
        #endregion

        #region Properties
        private TData _data;

        public TData Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }
        #endregion

        #region Methods
        public virtual void SetData(TData data)
        {
            Data = data;
        }
        #endregion
    }

    public abstract class BaseViewModel : BindableBase, IViewModel, IDataErrorInfo
    {
        #region Fields
        private Dictionary<string, string> _errorCollection = new Dictionary<string, string>();
        #endregion

        #region Properties
        public abstract string Title { get; }

        /// <summary>
        /// Returns true if the ViewModel is busy of long operation
        /// </summary>
        public virtual bool IsBusy { get; protected set; }

        public bool WasModelChanged { get; set; }

        public Dictionary<string, string> ErrorCollection
        {
            get => _errorCollection;
            private set => SetProperty(ref _errorCollection, value);
        }
        #endregion

        #region IDataErrorInfo
        public string Error => null;

        /// <summary>
        /// Calls on changes of property
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public virtual string this[string propName]
        {
            get
            {
                string result = null;

                switch (propName)
                {
                    default:
                        ClearErrors(propName);
                        break;
                }

                AddErrorToCollection(propName, result);

                return result;
            }
        }

        /// <summary>
        /// Flag of presence of errors in collection
        /// </summary>
        public virtual bool HasErrors => ErrorCollection.Any();

        /// <summary>
        /// Cleans out errors for a current property
        /// </summary>
        /// <param name="propName">Property name</param>
        public virtual void ClearErrors(string propName)
        {
            if (ErrorCollection.ContainsKey(propName))
            {
                ErrorCollection.Remove(propName);
            }
        }

        /// <summary>
        /// Adds errors in dictionary
        /// </summary>
        /// <param name="propName">Property name</param>
        /// <param name="errorMessage">Error message</param>
        public virtual void AddErrorToCollection(string propName, string errorMessage)
        {
            if (ErrorCollection.ContainsKey(propName)) ErrorCollection[propName] = errorMessage;
            else if (errorMessage != null) ErrorCollection.Add(propName, errorMessage);
        }
        #endregion
    }
}