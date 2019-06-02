using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Views;
using Xamarin.Forms;

namespace Taxi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void gotodriver(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new DriverLogin(), true);
        }

        private async void Reservation(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new Customer(), true);
        }
    }
}


