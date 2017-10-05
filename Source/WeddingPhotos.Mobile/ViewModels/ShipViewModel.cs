using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeddingPhotos.Mobile.Models;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class ShipViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ShipViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            InitializeDecks();
            OpenDeck = new RelayCommand(OnOpenDeck);
        }

        public ObservableCollection<ShipDeck> Decks { get; set; }
        public ICommand OpenDeck { get; set; }

        private void OnOpenDeck()
        {
            _navigationService.NavigateTo(nameof(App.Locator.ShipDeck));
        }

        private void InitializeDecks()
        {
            var decks = new []
            {
                new ShipDeck("Deck 3", "deck3.png")
            };

            Decks = new ObservableCollection<ShipDeck>(decks);
            RaisePropertyChanged(nameof(Decks));
        }
    }
}
