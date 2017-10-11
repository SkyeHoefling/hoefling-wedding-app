using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : CarouselPage
    {
		public HomePage ()
		{
			InitializeComponent ();
		}
	}
}