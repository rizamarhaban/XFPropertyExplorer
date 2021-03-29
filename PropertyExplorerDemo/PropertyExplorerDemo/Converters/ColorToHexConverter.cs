using System;
using System.Globalization;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace PropertyExplorerDemo.Converters
{
    public class ColorToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return ColorConverters.FromHex("ff000000");

            return ColorConverters.FromHex(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "ff000000";

            var color = (Color)value;

            return color.ToHex();
        }
    }
}
