using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace HalloMVVM.Converters
{
    public class KeyBindingToStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var modifiers = (ModifierKeys)values[0];
            var key = (Key)values[1];

            return $"{modifiers}+{key}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
