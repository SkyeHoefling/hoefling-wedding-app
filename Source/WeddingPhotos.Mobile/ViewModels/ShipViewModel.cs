using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeddingPhotos.Mobile.Models;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class ShipViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ShipViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            InitializeDecks();
            OpenDeck = new RelayCommand<ItemTappedEventArgs>(OnOpenDeck);
        }

        public ObservableCollection<ShipDeck> Decks { get; set; }
        public ICommand OpenDeck { get; set; }

        private void OnOpenDeck(ItemTappedEventArgs itemSelected)
        {
            var item = (ShipDeck)itemSelected.Item;
            _navigationService.NavigateTo(nameof(App.Locator.ShipDeck), item);
        }

        private void InitializeDecks()
        {
            var decks = new []
            {
                new ShipDeck("Deck 3", "deck3.png", "deck3_map.png")
            };

            Decks = new ObservableCollection<ShipDeck>(decks);
            RaisePropertyChanged(nameof(Decks));
        }
    }
}
