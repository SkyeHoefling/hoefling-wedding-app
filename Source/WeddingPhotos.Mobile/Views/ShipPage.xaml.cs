using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShipPage : ContentPage
	{
		public ShipPage()
		{
			InitializeComponent();
            BindingContext = App.Locator.Ship;
		}
	}
}