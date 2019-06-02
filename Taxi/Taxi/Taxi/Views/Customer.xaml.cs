using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taxi.DataObjects;
using Utaxi65Service.DataObjects;

namespace Taxi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Customer : ContentPage
	{
		public Customer ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Logo.Source = ImageSource.FromFile("logo.png");
		}

        private async  void FindMyPlace(object sender, EventArgs e)
        {
            CurrentPlatform.Init();
            Info info = new Info() { First = First.Text, Last = Last.Text, Telephone = Telephone.Text };
           // await App.MobileService.GetTable<Info>().InsertAsync(info);
            await this.Navigation.PushAsync(new Map(info), true);
        }

        private async void DateATaxi(object sender, EventArgs e)
        {
            CurrentPlatform.Init();
            Info info = new Info() { First = First.Text, Last = Last.Text, Telephone = Telephone.Text };
           // await App.MobileService.GetTable<Info>().InsertAsync(new Info() );
            await this.Navigation.PushAsync(new DateMap(info), true);
        }
    }
}