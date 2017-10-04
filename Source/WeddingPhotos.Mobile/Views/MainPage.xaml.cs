using WeddingPhotos.Mobile.Services;
using WeddingPhotos.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainViewModel(new ImageService());
		}
	}
}
