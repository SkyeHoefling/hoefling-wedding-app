using WeddingPhotos.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShipDeckPage : ContentPage
	{
		public ShipDeckPage(ShipDeck model)
		{
			InitializeComponent ();
            var context = App.Locator.ShipDeck;
            context.Initialize(model);
            BindingContext = context;
		}
	}
}