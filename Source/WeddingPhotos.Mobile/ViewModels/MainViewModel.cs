using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Navigate = new RelayCommand<string>(OnNavigate);
        }
        public ICommand Navigate { get; set; }

        public void OnNavigate(string location)
        {
            _navigationService.NavigateTo(location);
        }
    }
}
