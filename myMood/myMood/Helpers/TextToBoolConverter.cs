using System;
using System.Globalization;
using Xamarin.Forms;

namespace myMood.Helpers
{
    public class TextToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                if (!(value is string)) return true;
            return string.IsNullOrWhiteSpace(value as string) ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
