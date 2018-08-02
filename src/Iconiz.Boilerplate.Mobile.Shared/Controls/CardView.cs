using Xamarin.Forms;

namespace Iconiz.Boilerplate.Controls
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;

            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = false;
                OutlineColor = Color.Gray;
            }
        }
    }
}

