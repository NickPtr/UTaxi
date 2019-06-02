
using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utaxi65Service.DataObjects;
using Microsoft.WindowsAzure.MobileServices;
using Acr.UserDialogs;

namespace Taxi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class Map : ContentPage
	{
        public Info info;

        public Map(Info info)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            FindMe.Clicked += FindMyLocation;
            this.info = info;

        }

        private async void FindMyLocation(object sender, System.EventArgs e)
        {
            await RetrieveLocation();
        }

        private async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
        }

        private async void end_app2(object sender, EventArgs e)
        {
            retrieveLocation1();
            await this.Navigation.PushAsync(new FinalPage(), true);
        }
        public async void retrieveLocation1()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            CurrentPlatform.Init();
            this.info.Long = position.Longitude;
            this.info.Lat = position.Latitude;
            UserDialogs.Instance.ShowLoading("Loading...");
            await App.MobileService.GetTable<Info>().InsertAsync(info);
            UserDialogs.Instance.HideLoading();
        }
    }
}
