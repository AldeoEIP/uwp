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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Aldeo.View {
    public sealed partial class Header : UserControl {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Header), new PropertyMetadata("Undefined"));

        public string Title {
            get { return (string) GetValue (TitleProperty); }
            set { SetValue (TitleProperty, value); }
        }

        public Header() {
            this.InitializeComponent ();

            Loaded += Header_Loaded;
        }

        // todo: Use binding!
        private void Header_Loaded(object sender, RoutedEventArgs e) {
            HeaderBlock.Text = Title;
        }
    }
}
