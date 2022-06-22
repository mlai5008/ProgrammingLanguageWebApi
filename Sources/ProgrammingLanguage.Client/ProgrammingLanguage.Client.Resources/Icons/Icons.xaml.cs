using ProgrammingLanguage.Client.Resources.Brushes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProgrammingLanguage.Client.Resources.Icons
{
    /// <summary>
    /// Логика взаимодействия для Icons.xaml
    /// </summary>
    public partial class Icons : ResourceDictionary
    {
        #region ctor
        public Icons()
        {
            InitializeComponent();
            IconHelper.InitializeImages(this);
        }
        #endregion
    }

    public static class IconHelper
    {
        #region Fields
        private static readonly Dictionary<string, string> _iconResourceMapping = new Dictionary<string, string>
        {
            {IconKey.MinusSmall , FileIconKey.MinusSmall},
            {IconKey.CloseWindowSmall , FileIconKey.CloseWindowSmall},
            {IconKey.EditSmall , FileIconKey.EditSmall},
        };

        private static readonly Dictionary<string, string> _iconCustomBrushes = new Dictionary<string, string>
        {
            {IconKey.MinusSmall, BrushKey.MainLightBrush},
            {IconKey.CloseWindowSmall, BrushKey.MainLightBrush},
            {IconKey.EditSmall , BrushKey.MainLightBrush},
        }; 
        #endregion

        #region Methods
        public static string GetFileIconKeyByIconKey(string iconKey) => _iconResourceMapping[iconKey];

        public static void InitializeImages(ResourceDictionary dictionary)
        {
            foreach (var item in _iconResourceMapping)
            {
                string key = item.Key;
                string colorBrush = GetColorBrush(key, BrushKey.MainLightBrush);
                object value = FileIconContent.GetDrawingImage(item.Value, colorBrush);
                AddResource(dictionary, key, value);
            }
            foreach (var item in _iconResourceMapping)
            {
                string key = IconKey.GetTemplateKey(item.Key);
                string fileImageKey = item.Value;
                object value = FileIconContent.GetDrawingImageTemplate(fileImageKey);
                AddResource(dictionary, key, value);
            }
        }

        private static string GetColorBrush(string key, string defaultColorBrush)
        {
            return _iconCustomBrushes.ContainsKey(key) ? _iconCustomBrushes[key] : defaultColorBrush;
        }

        private static void AddResource(ResourceDictionary dictionary, string key, object value)
        {
            try
            {
                dictionary.Add(key, value);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}