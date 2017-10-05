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
                new ShipDeck("Deck 3", "deck3.png", "deck3_map.png"),
                new ShipDeck("Deck 4", "deck4.png", "deck4_map.png"),
                new ShipDeck("Deck 5", "deck5.png", "deck5_map.png"),
                new ShipDeck("Deck 6", "deck6.png", "deck6_map.png"),
                new ShipDeck("Deck 7", "deck7.png", "deck7_map.png"),
                new ShipDeck("Deck 8", "deck8.png", "deck8_map.png"),
                new ShipDeck("Deck 9", "deck9.png", "deck9_map.png"),
                new ShipDeck("Deck 10", "deck10.png", "deck10_map.png"),
                new ShipDeck("Deck 11", "deck11.png", "deck11_map.png"),
                new ShipDeck("Deck 12", "deck12.png", "deck12_map.png"),
                new ShipDeck("Deck 13", "deck13.png", "deck13_map.png"),
                new ShipDeck("Deck 14", "deck14.png", "deck14_map.png"),
                new ShipDeck("Deck 15", "deck15.png", "deck15_map.png"),
                new ShipDeck("Deck 16", "deck16.png", "deck16_map.png"),
            };

            Decks = new ObservableCollection<ShipDeck>(decks);
            RaisePropertyChanged(nameof(Decks));
        }
    }
}
