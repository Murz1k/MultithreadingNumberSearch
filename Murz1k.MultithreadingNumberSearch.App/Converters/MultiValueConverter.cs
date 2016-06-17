using System;
using System.Globalization;
using System.Windows.Data;
namespace Murz1k.MultithreadingNumberSearch.App.Converters
{
    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name = values[0] as string;
            string date = values[1] as string;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(date))
            {
                return String.Format("{0} - {1}",name,date);
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return (value as string).Split('-');
        }
    }
}
