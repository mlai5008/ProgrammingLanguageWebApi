using ProgrammingLanguage.Client.Infrastructure.Interfaces.Views.Base;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Linq;
using System.Reflection;

namespace ProgrammingLanguage.Client.Infrastructure.Extensions
{
    public static class ViewExtensions
    {
        #region Fields
        private static IContainerProvider _container;
        #endregion

        #region ctor
        static ViewExtensions()
        {
            _container = ContainerLocator.Container.Resolve<IContainerProvider>();
        }
        #endregion

        #region Methods
        public static TView GetView<TView>() where TView : IView
        {
            return _container.Resolve<TView>();
        }

        public static TView SetDataContext<TView>(this TView view) where TView : IView
        {
            Type viewModelType = FindViewDataContext(view);

            view.DataContext = viewModelType != null ? _container.Resolve(viewModelType) : null;

            return view;
        }

        private static Type FindViewDataContext<TView>(TView view) where TView : IView
        {
            Assembly assem = typeof(TView).Assembly;
            return assem.DefinedTypes.FirstOrDefault(tpnm => tpnm.Name.Equals("I" + view.GetType().Name + "Model"));
        }

        public static TView ActivateRegionWithView<TView>(this TView view, string regionName) where TView : IView
        {
            view.SetDataContext();

            IRegionManager regionManager = _container.Resolve<IRegionManager>();

            if (!regionManager.Regions.ContainsRegionWithName(regionName))
            {
                IRegion region = new Region { Name = regionName };
                regionManager.Regions.Add(region);
            }

            if (!regionManager.Regions[regionName].Views.Contains(view))
            {
                regionManager.AddToRegion(regionName, view);
            }

            return view;
        }
        #endregion
    }
}