using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OniTemplate.Editor
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = "/OniTemplate;component/Images/" + (value?.ToString() ?? "placeholder");
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
