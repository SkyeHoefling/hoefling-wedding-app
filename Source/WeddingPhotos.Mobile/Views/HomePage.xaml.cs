using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeddingPhotos.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            BindingContext = new
            {
                Data = new[]
                {
                    "Test1",
                    "Test2",
                    "Test3"
                }
            };
		}
	}
}