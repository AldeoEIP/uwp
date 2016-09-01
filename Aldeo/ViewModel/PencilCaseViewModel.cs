using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Aldeo.Model;
using GalaSoft.MvvmLight.Command;

namespace Aldeo.ViewModel {
    public class PencilCaseViewModel {
        public string Message { get; set; }
        public IEnumerable<MenuTile> Menu { get; set; }

        public ICommand LoadedCommand { get; set; }
        public ICommand ChangedSelection { get; set; }
        public ICommand ClickedAccount { get; set; }

        //public RelayCommand<ItemClickEventArgs> ItemSelectedCommand { get; set; }
        //public RelayCommand ItemSelectedCommand { get; set; }
        private readonly INavigationService _navigationService = new NavigationService();

        public PencilCaseViewModel() {
            Message = "He is alive! Alive!";
            Menu = new[]
            {
                new MenuTile('', "Calculatrice", "Calculator"),
                new MenuTile('', "Dictionnaire", "Dictionary"),
                new MenuTile('', "Encyclopédie", "Encyclopedia"),
                new MenuTile('', "Traducteur", "Translator")
            };

            LoadedCommand = new RelayCommand (LoadedExecute);
            ChangedSelection = new RelayCommand<MenuTile> (SelectionChangedExecute);
            ClickedAccount = new RelayCommand (AccountClickedExecute);

            // https://marcominerva.wordpress.com/2014/01/10/windows-8-1-behavior-sdk-how-to-use-invokeaction-with-inputconverter-to-pass-arguments-to-a-command/
            //ItemSelectedCommand = new RelayCommand (() =>
            //{
            //    // navigation to
            //});
        }

        private static void AccountClickedExecute() {
            //_navigationService.Navigate (typeof (AccountPage));
        }

        private void SelectionChangedExecute(MenuTile tile) {
            if (tile.Tag == "Translator") {
                ShowNotAvailable (tile.Title);
                return;
            }
            _navigationService.Navigate ($"Aldeo.View.{tile.Tag}Page");
        }

        private void LoadedExecute() {

        }

        private static async void ShowNotAvailable(string name) {
            var dialog = new MessageDialog ($"{name} n'est pas encore disponible. Suivez nous sur @AldeoEip pour obtenir nos actualités en direct !");
            await dialog.ShowAsync ();
        }
    }
}
