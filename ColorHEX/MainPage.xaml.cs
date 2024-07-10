using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorHEX
{
    public partial class MainPage : ContentPage
    {
        string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Color_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);

        }

        private void SetColor(Color color)
        {
            //Debug.WriteLine(color.ToString());
            btnRandom.Background = color;
            Container.Background = color;
            hexValue = color.ToHex();
            lblHEX.Text = hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256)
                );

            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;   
            sldBlue.Value = color.Blue;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color copiado",
                CommunityToolkit.Maui.Core.ToastDuration.Short, 
                14);
            await toast.Show();
        }
    }

}
