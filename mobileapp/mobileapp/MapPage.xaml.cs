
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace mobileapp
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        IGeolocator locator = CrossGeolocator.Current;
        public MapPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetLocation();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locator.StopListeningAsync();
        }
        private async void GetLocation()
        {
            var status = await CheckandRequestLocationPermission();
            if (status == PermissionStatus.Granted)
            {
                
                locator.PositionChanged += Locator_PositionChange;
                var location = await Geolocation.GetLastKnownLocationAsync();
                await locator.StartListeningAsync(new TimeSpan(0,1,0),100);
                LocationMap.IsShowingUser = true;
                CenterMap(location.Latitude, location.Longitude);
            }
        }

        private void Locator_PositionChange(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
           CenterMap(e.Position.Latitude, e.Position.Longitude);
        }


        private void CenterMap(double latitude, double longitude)
        {
            Xamarin.Forms.Maps.Position center = new Xamarin.Forms.Maps.Position(latitude, longitude);
            MapSpan span = new MapSpan(center, 1, 1);
            LocationMap.MoveToRegion(span);
        }

        private async Task<PermissionStatus> CheckandRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
                return status;

            if(status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //promt user to turn on user permission setting
                return status;
            }
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;

        }
    }
}