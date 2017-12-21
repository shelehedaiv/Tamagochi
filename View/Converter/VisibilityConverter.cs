using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace View.Converter
{
    public class VisibilityConverter:IValueConverter    
    {
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility) value;
            switch (visibility)
            {
                case Visibility.Visible: return true;
                case Visibility.Collapsed: return false;
                case Visibility.Hidden: return false;
            }
            return false;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var isVisible = (bool) value;
            if (isVisible) return Visibility.Visible;
            else return Visibility.Collapsed;
        }
    }
}