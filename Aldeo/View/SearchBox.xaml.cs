using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Aldeo.View {
    public sealed partial class SearchBox {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(SearchBox), new PropertyMetadata(""));

        public string Icon { // 
            get { return (string) GetValue (IconProperty); }
            set { SetValue (IconProperty, value); }
        }

        public SearchBox() {
            InitializeComponent ();

            DataContext = this;

            Loaded += SearchBox_Loaded;
        }

        // todo: Use binding!
        private void SearchBox_Loaded(object sender, RoutedEventArgs e) {
            Button.Content = Icon;
        }

        // http://wbsimms.com/mvvm-light-toolkit-messaging-example/
        private void Button_Click(object sender, RoutedEventArgs e) {
            Messenger.Default.Send (Box.Text);
        }
    }
}
