using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        public MainViewModel(
            INavigationService navigationService,
            IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            Navigate = new RelayCommand<string>(OnNavigate);
        }
        public ICommand Navigate { get; set; }

        public void OnNavigate(string location)
        {
            if (location == nameof(App.Locator.Gallery))
                _dialogService.ShowMessage("This feature is not implemented yet", "Not Implemented");
            else
                _navigationService.NavigateTo(location);
            
        }
    }
}
