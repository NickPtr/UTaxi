using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DataObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using Utaxi65Service.DataObjects;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using Acr.UserDialogs;

namespace Taxi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriversLastPage : ContentPage
	{
        public DriversLastPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Logo.Source = ImageSource.FromFile("logo.png");
            Load_Info();
        }
        public async void Load_Info()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");
                var UserTable = App.MobileService.GetTable<Info>();

                var result = await UserTable.Where(x => x.First!=string.Empty).ToListAsync();
                var Name = result.FirstOrDefault();
                First1.Text = Name.First;
                Last1.Text = Name.Last;
                Telephone1.Text = Name.Telephone;
                Date1.Text = Name.Date;
                Time1.Text = Name.Time;
                double Lat = Convert.ToDouble(Name.Lat);
                double Long = Convert.ToDouble(Name.Long);

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 20;

                var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Lat,Long), Distance.FromMiles(1)));
                  var pos = new Position(Lat, Long); // Latitude, Longitude
                  var pin = new Pin
                  {
                      Type = PinType.Place,
                      Position = pos,
                      Label = "custom pin",
                      Address = "custom detail info"
                  };
                  MyMap.Pins.Add(pin);
                UserDialogs.Instance.HideLoading();
            }
            catch(Exception x )
            {

            }
            
        }
  
	}
}