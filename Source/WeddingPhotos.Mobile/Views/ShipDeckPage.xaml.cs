using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShipDeckPage : ContentPage
	{
		public ShipDeckPage ()
		{
			InitializeComponent ();
            BindingContext = App.Locator.ShipDeck;
		}
	}
}