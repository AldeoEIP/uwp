using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Aldeo.ViewModel {
    public class CalculatorViewModel {
        public ICommand ClickedSearch { get; set; }

        public CalculatorViewModel() {
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