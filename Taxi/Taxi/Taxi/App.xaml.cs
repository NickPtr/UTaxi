using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;

namespace Taxi
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage =new NavigationPage( new Taxi.MainPage());
		}
        public static MobileServiceClient MobileService = new MobileServiceClient("https://utaxiserver.azurewebsites.net");
       

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        
    }
    
}
