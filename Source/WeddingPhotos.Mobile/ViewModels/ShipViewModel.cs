using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class ShipViewModel : ViewModelBase
    {
        public ShipViewModel()
        {
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
        }

        public ObservableCollection<string> Decks { get; set; }
    }
}
