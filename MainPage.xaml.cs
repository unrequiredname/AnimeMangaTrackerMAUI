using AnimeMangaTrackerMAUI.Models;
using Newtonsoft.Json;

namespace AnimeMangaTrackerMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void OnCategoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage());
        }

        async private void OnMediaItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MediaItemPage());
        }

        async private void OnProgressClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgressPage());
        }
    }

}
