using System;
using System.Globalization;
using System.Windows.Data;

namespace ProgrammingLanguage.Client.Resources.Converters
{

    public class InvertibleBooleanToIsEnabledConverter : IValueConverter
    {
        private enum Parameters
        {
            Normal, Inverted
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value != null && (bool)value;
            Parameters direction = (Parameters)Enum.Parse(typeof(Parameters), (string)parameter ?? string.Empty);

            if (direction == Parameters.Inverted)
                return !boolValue;

            return boolValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}