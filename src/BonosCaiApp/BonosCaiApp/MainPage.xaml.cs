using System;
using Xamarin.Forms;

namespace BonosCaiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoPage_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var status = BonosWebClient.GetStatus();
            if (status)
                Status.Text = "La venta de bonos está habilitada!";
            else
                Status.Text = "La venta de bonos está cerrada";
        }
    }
}
