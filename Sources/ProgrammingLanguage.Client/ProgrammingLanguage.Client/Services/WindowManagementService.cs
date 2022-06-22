using ProgrammingLanguage.Client.Infrastructure.Interfaces.Services;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.ViewModels.Base;
using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Base;
using Prism.Ioc;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ProgrammingLanguage.Client.Services
{
    public class WindowManagementService : IWindowManagementService
    {
        #region Constants
        private const string _removeCharacters = "Model";
        #endregion

        #region Fields
        private readonly IContainerProvider _containerProvider;
        private readonly int _numberRemoveCharacters;
        #endregion

        #region ctor
        public WindowManagementService()
        {
            _numberRemoveCharacters = _removeCharacters.Length;
        }

        public WindowManagementService(IContainerProvider containerProvider) : this()
        {
            _containerProvider = containerProvider;
        }
        #endregion

        #region Methods
        public void Minimaze<TViewModel>() where TViewModel : IViewModel
        {
            IMainView window = GetWindow<TViewModel>();

            if (window != null) window.WindowState = WindowState.Minimized;
        }

        public void Drag<TViewModel>() where TViewModel : IViewModel
        {
            IMainView window = GetWindow<TViewModel>();

            if (window != null) window.DragMove();
        }

        private IMainView GetWindow<TViewModel>() where TViewModel : IViewModel
        {
            string viewModelName = typeof(TViewModel).Name;

            string viewName = viewModelName.Remove(viewModelName.Length - _numberRemoveCharacters, _numberRemoveCharacters);

            Assembly assem = typeof(TViewModel).Assembly;
            Type viewType = assem.DefinedTypes.FirstOrDefault(tpnm => tpnm.Name.Equals(viewName));

            return _containerProvider.Resolve(viewType) as IMainView;
        }
        #endregion
    }
}