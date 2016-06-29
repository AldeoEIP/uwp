using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aldeo {
    public interface INavigationService {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void Navigate(string sourcePage);
        void Navigate(string sourcePage, object parameter);
        void GoBack();
        void GoForward();
    }
}
