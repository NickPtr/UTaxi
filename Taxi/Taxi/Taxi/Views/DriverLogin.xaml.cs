using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taxi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverLogin : ContentPage
	{
		public DriverLogin ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Logo.Source = ImageSource.FromFile("logo.png");         
        }

        private async void Login1(object sender, EventArgs e)
        {
            if(Username.Text=="admin" && Password.Text=="admin")
            {
                await this.Navigation.PushAsync(new DriversLastPage(), true);
            }
            else
            {
                DisplayAlert("Μύνημα", "Λάθος Στοιχεία", "ΠΡΟΣΠΑΘΗΣΕ ΞΑΝΑ");
            }

        }
    }
}