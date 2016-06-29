using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SharpDeo;

namespace Aldeo.ViewModel {
    public class DictionaryViewModel : ViewModelBase {
        public ICommand ClickedSearch { get; set; }
        Client client = new Client ();
        public string Answer { get; set; }

        public DictionaryViewModel() {
            ClickedSearch = new RelayCommand<string> (SearchClickedExecute);
            Connect();
            Answer = "";
            Messenger.Default.Register<string>(this, SearchClickedExecute);
        }

        private async void Connect()
        {
            var task = client.LoginAsync ("toto42", "toto42").ConfigureAwait (false);
            await task;
        }

        private async void SearchClickedExecute(string input) {
            var answer = await SearchAsync (input).ConfigureAwait(false);

            var dialog = new MessageDialog (answer);
            await dialog.ShowAsync ();
            //RaisePropertyChanged (() => Answer);
        }

        private async Task<string> SearchAsync(string input) {
            var result = await client.GetDictionaryDefintionAsync (input).ConfigureAwait (false);
            return result;
        }
    }
}
