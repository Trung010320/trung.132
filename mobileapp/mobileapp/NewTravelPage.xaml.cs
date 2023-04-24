using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobileapp.Model;
using Plugin.Geolocator;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobileapp.Logic;

    

namespace mobileapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venue = Venue_logic.GetVenues(position.Latitude, position.Longitude);
            
           
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = ExperienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocatin)) { 
            conn.CreateTable<Post>();
            int rows = conn.Insert(post);
                if (rows > 0)
                    DisplayAlert("Success", "Insert successflly", "Done");
                else
                    DisplayAlert("Failure", "Insert fail  ", "Done");
            }

        }
    }
}