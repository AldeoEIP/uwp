using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Aldeo.ViewModel {
    public class TranslatorViewModel {
        public ICommand ClickedSearch { get; set; }

        public TranslatorViewModel() {
            ClickedSearch = new RelayCommand<string> (SearchClickedExecute);
        }

        private void SearchClickedExecute(string input) {
            var answer = SearchAsync (input);
        }

        private string SearchAsync(string input) {
            throw new System.NotImplementedException ();
        }
    }
}
