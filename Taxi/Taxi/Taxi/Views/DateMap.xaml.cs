using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System;
using Utaxi65Service.DataObjects;
using Microsoft.WindowsAzure.MobileServices;
using Acr.UserDialogs;

namespace Taxi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateMap : ContentPage
    {
        public Info info;
        public DateMap(Info info)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            FindMe.Clicked += FindMyLocation;
            this.info = info;

        }

        private async void FindMyLocation(object sender, System.EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
        }
        public async void end_app(object sender, EventArgs e)
        {
            retrieveLocation();
            await this.Navigation.PushAsync(new FinalPage(), true);
        }

        public async void retrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            CurrentPlatform.Init();
            this.info.Long = position.Longitude;
            this.info.Lat = position.Latitude;
            this.info.Date = Date.Text;
            this.info.Time = Time.Text;
            UserDialogs.Instance.ShowLoading("Loading...");
            await App.MobileService.GetTable<Info>().InsertAsync(info);
            UserDialogs.Instance.HideLoading();
        }
    }
}
