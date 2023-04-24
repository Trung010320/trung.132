using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobileapp.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetail : ContentPage
    {
        Post seletedPost;
        public PostDetail(Post selectedPost)
        {
            this.seletedPost = selectedPost;
            InitializeComponent();
            ExperienceEntry.Text = selectedPost.Experience;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            seletedPost.Experience = ExperienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocatin))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(seletedPost);
                if (rows > 0)
                    DisplayAlert("Success", " Experience successflly updated", "Done");
                else
                    DisplayAlert("Failure", "experience failed to be updated  ", "Done");
            }

        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocatin))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(seletedPost);
                if (rows > 0)
                    DisplayAlert("Success", "Experience successflly deleted", "Done");
                else
                    DisplayAlert("Failure", "Experience failed to be deleted", "Done");
            }
        }
    }
}