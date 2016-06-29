using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;

namespace Aldeo.View.Converter {
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets"/>
    public class TitleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var key = value as string;
            if (string.IsNullOrEmpty (key))
                return value;
            var loader = ResourceLoader.GetForCurrentView ();
            var translation = loader.GetString(key);
            return translation;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}