using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobileapp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocatin))
            {


                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList(); // going to the db and return table qery oblject with the psot table
                postListview.ItemsSource = posts;
               
            }
        }

        private void postListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListview.SelectedItem as Post;
            if( selectedPost != null)
            {
                Navigation.PushAsync(new PostDetail(selectedPost));

            }
        }
    }
}