using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Aldeo {
    public sealed class NavigationService : INavigationService {

        // alternative to void Navigate(Type t)
        //public void Navigate(Type sourcePage) {
        //    Navigate (sourcePage, null);
        //}
        // or with paramterless
        //public void Navigate(Type sourcePage, object paramter = null) {
        //    Navigate (sourcePage, parameter);
        //}
        public void Navigate(Type sourcePage) {
            var frame = (Frame) Window.Current.Content;
            frame.Navigate (sourcePage);
        }

        public void Navigate(Type sourcePage, object parameter) {
            var frame = (Frame) Window.Current.Content;
            frame.Navigate (sourcePage, parameter);
        }

        public void Navigate(string sourcePage) {
            Navigate (Type.GetType (sourcePage));
        }
        public void Navigate(string sourcePage, object parameter) {
            Navigate (Type.GetType (sourcePage), parameter);
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history, if a Frame manages its own navigation history.
        /// </summary>
        public void GoForward() {
            // Frame.CanGoForward()?
            Go (true);
        }
        /// <summary>
        /// Navigates to the most recent item in back navigation history, if a Frame manages its own navigation history.
        /// </summary>
        public void GoBack() {
            // Frame.CanGoBack()?
            Go (false);
        }

        private static void Go(bool isForward) {
            var frame = (Frame) Window.Current.Content;
            if (isForward)
                frame.GoForward ();
            else
                frame.GoBack ();
        }
    }
}
