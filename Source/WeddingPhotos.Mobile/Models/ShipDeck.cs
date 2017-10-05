using Xamarin.Forms;

namespace WeddingPhotos.Mobile.Models
{
    public class ShipDeck
    {
        public ShipDeck(string name, string menuImage, string mapImage)
        {
            Name = name;
            MenuSource = ImageSource.FromFile(menuImage);
            MapSource = ImageSource.FromFile(mapImage);
        }

        public string Name { get; set; }
        public ImageSource MenuSource { get; set; }
        public ImageSource MapSource { get; set; }
    }
}
