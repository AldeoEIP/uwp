using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Aldeo.View {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlarmPage : Page {
        public AlarmPage() {
            this.InitializeComponent ();
        }

        private static readonly Random Random = new Random();

        const string TOAST = @"
<toast>
  <visual>
    <binding template=""ToastGeneric"">
      <text>Sample</text>
      <text>This is a simple toast notification example</text>
      <image placement = ""AppLogoOverride"" src=""http://media.meltybuzz.fr/article-1342570-ajust_930/un-poney.jpg"" />
    </binding>
  </visual>
  <actions>
    <action content = ""check"" arguments=""check"" imageUri=""check.png"" />
    <action content = ""cancel"" arguments=""cancel""/>
  </actions>
  <audio src =""ms-winsoundevent:Notification.Reminder""/>
</toast>";

        private void Button_Click(object sender, RoutedEventArgs e) {
            var when = DateTime.Now.AddSeconds (10);
            var offset = new DateTimeOffset (when);
            var xml = new Windows.Data.Xml.Dom.XmlDocument ();

            xml.LoadXml (TOAST);
            var toast = new ScheduledToastNotification (xml, offset) {
                Id = Random.Next (1, 100000000).ToString ()
            };
            ToastNotificationManager.CreateToastNotifier ().AddToSchedule (toast);
        }
    }
}
