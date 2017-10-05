using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class ShipViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ShipViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            var decks = new[]
            {
                "Deck 1",
                "Deck 2",
                "Deck 3",
                "Deck 4",
                "Deck 5",
                "Deck 6",
                "Deck 7",
                "Deck 8",
            };

            Decks = new ObservableCollection<string>(decks);
            RaisePropertyChanged(nameof(Decks));

            OpenDeck = new RelayCommand(OnOpenDeck);
        }

        public ObservableCollection<string> Decks { get; set; }
        public ICommand OpenDeck { get; set; }

        private void OnOpenDeck()
        {
            _navigationService.NavigateTo(nameof(App.Locator.ShipDeck));
        }
    }
}
