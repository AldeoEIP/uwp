using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SharpDeo;

namespace Aldeo.ViewModel {
    public class DictionaryViewModel : ViewModelBase {
        public ICommand ClickedSearch { get; set; }
        public ICommand LoadedCommand { get; set; }

        Client client = new Client ();
        public string Answer { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public DictionaryViewModel() {
            ClickedSearch = new RelayCommand<string> (SearchClickedExecute);
            LoadedCommand = new RelayCommand (LoadedExecute);
            Answer = "";
            Title = "";
            Url = "";
        }

        private async void LoadedExecute() {
            await ConnectAsync ().ConfigureAwait (false);
            Messenger.Default.Register<string> (this, SearchClickedExecute);
            Debug.WriteLine("connected");
        }

        private Task ConnectAsync() {
            var task = client.LoginAsync ("toto42", "toto42");
            return task;
        }

        private async void SearchClickedExecute(string input) {
            try {
                var result = await client.GetDictionaryDefintionAsync (input).ConfigureAwait (false);

                var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;

                await dispatcher.RunAsync (Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                    Title = result.Title;
                    Answer = result.Extract;
                    //Url = result.DetailUrl;
                    //RaisePropertyChanged (() => Title);
                    //RaisePropertyChanged (() => Answer);

                    RaisePropertyChanged ("Title");
                    RaisePropertyChanged ("Answer");

                    //RaisePropertyChanged (() => Url);
                });

            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
