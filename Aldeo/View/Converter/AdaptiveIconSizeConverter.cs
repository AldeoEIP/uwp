using System;
using Windows.UI.Xaml.Data;

namespace Aldeo.View.Converter {
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets"/>
    public class AdaptiveIconSizeConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var size = (double) value;
            return size * 33 / 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            var size = (double) value;
            return size / 33 * 100;
        }
    }
}