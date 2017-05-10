using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiConverters.Converters
{
    public class RgbToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var alpha = (byte)(double)values[0];
            var red = (byte)(double)values[1];
            var green = (byte)(double)values[2];
            var blue = (byte)(double)values[3];

            return new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var color = (value as SolidColorBrush).Color;

            return new object[]
            {
                (double)color.A,
                (double)color.R,
                (double)color.G,
                (double)color.B,
            };
        }
    }
}
