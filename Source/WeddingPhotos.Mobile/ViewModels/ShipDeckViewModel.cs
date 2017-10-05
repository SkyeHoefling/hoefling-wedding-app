using GalaSoft.MvvmLight;
using WeddingPhotos.Mobile.Models;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class ShipDeckViewModel : ViewModelBase
    {
        public ShipDeckViewModel()
        {

        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private ImageSource _source;
        public ImageSource Source
        {
            get { return _source; }
            set
            {
                _source = value;
                RaisePropertyChanged(nameof(Source));
            }
        }

        public void Initialize(ShipDeck model)
        {
            Title = model.Name;
            Source = model.MapSource;
        }
    }
}
