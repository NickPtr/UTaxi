using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utaxi65Service.DataObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;


namespace Taxi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FinalPage : ContentPage
	{
		public FinalPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Logo.Source = ImageSource.FromFile("logo.png");
        }
	}
}