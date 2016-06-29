using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Aldeo.ViewModel {
    public class EncyclopediaViewModel {

        public ICommand ClickedSearch { get; set; }

        public EncyclopediaViewModel() {
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