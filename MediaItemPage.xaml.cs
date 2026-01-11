using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI;

public partial class MediaItemPage : ContentPage
{
    public MediaItemPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            listViewMedia.ItemsSource = await App.Database.GetMediaItemsAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", "Nu am putut încărca lista: " + ex.Message, "OK");
        }
    }

    
    async void OnAddClicked(object sender, EventArgs e)
    {
       
        await Navigation.PushAsync(new MediaItemEntryPage
        {
            BindingContext = new MediaItem()
        });
    }

    
    async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MediaItemEntryPage
            {
                BindingContext = e.SelectedItem as MediaItem
            });
            listViewMedia.SelectedItem = null;
        }
    }

   
    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var item = menuItem.CommandParameter as MediaItem;

        if (item != null)
        {
            await App.Database.DeleteMediaItemAsync(item);
            listViewMedia.ItemsSource = await App.Database.GetMediaItemsAsync();
        }
    }
}