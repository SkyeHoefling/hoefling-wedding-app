using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageGalleryPage : ContentPage
	{
		public ImageGalleryPage()
		{
			InitializeComponent();
            BindingContext = App.Locator.Gallery;
		}
	}
}