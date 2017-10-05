using Xamarin.Forms;

namespace WeddingPhotos.Mobile.Models
{
    public class ShipDeck
    {
        public ShipDeck(string name, string image)
        {
            Name = name;
            Source = ImageSource.FromFile(image);
        }

        public string Name { get; set; }
        public ImageSource Source { get; set; }
    }
}
