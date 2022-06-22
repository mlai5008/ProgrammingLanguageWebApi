using ProgrammingLanguage.Client.Resources.Icons;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProgrammingLanguage.Client.Resources.Converters
{
    public class IconKeyToControlTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageKey = value?.ToString();
            if (!string.IsNullOrEmpty(imageKey))
            {
                if (Application.Current != null && Application.Current.TryFindResource(IconKey.GetTemplateKey(imageKey)) is ControlTemplate controlTemplate)
                {
                    return controlTemplate;
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}