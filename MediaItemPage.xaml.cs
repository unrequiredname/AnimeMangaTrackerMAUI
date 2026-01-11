namespace AnimeMangaTrackerMAUI;
using AnimeMangaTrackerMAUI.Models;
using System.Collections.ObjectModel;
public partial class MediaItemPage : ContentPage
{
    public ObservableCollection<MediaItem> MediaItems { get; set; } = new ObservableCollection<MediaItem>();
    public MediaItemPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetMediaItemsAsync();

        MediaItemsCollection.ItemsSource = items;

        MediaItems.Clear();
        foreach (var item in items)
        {
            MediaItems.Add(item);
        }
    }

    private async void OnAddNewMediaItemClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMediaItemPage());
    }

    private async void OnDeleteMediaItemClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;

        var mediaItem = (MediaItem)button.CommandParameter;

        if (mediaItem == null)
        {
            await DisplayAlert("Eroare", "Nu s-a putut identifica elementul pentru stergere.", "OK");
            return;
        }

        bool confirm = await DisplayAlert("Confirmare", $"Ștergi {mediaItem.Title}?", "Da", "Nu");
        if (confirm)
        {
            try
            {
                await App.Database.DeleteMediaItemAsync(mediaItem);
                
                var items = await App.Database.GetMediaItemsAsync();
                MediaItemsCollection.ItemsSource = items;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Eroare", $"Nu s-a putut șterge elementul: {ex.Message}", "OK");
            }
            
        }
    }


    private async void OnEditMediaItemClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var mediaItem = (MediaItem)button.CommandParameter;
        if (mediaItem != null)
        {
            var editPage = new AddMediaItemPage();

            editPage.BindingContext = mediaItem;

            await Navigation.PushAsync(editPage);
        }
    }



    //async void OnDeleteMediaItemClicked(object sender, EventArgs e)
    //{
    //    var mediaItems = (MediaItem)BindingContext;

            //    if (mediaItems.Id != 0)
            //    {
            //        bool answer = await DisplayAlert("Confirmare", message: $"Ștergi  {mediaItems.Title} ?", "Da", "Nu");
            //        if (answer)
            //        {
            //            await App.Database.DeleteMediaItemAsync(mediaItems);
            //            BindingContext = new MediaItem();
            //        }
            //    }
            //}

            //private async void OnEditMediaItemClicked(object sender, EventArgs e)
            //{
            //    var button = (Button)sender;
            //    var mediaItem = (MediaItem)button.CommandParameter;

            //    await Navigation.PushAsync(new AddMediaItemPage
            //    {
            //        BindingContext = mediaItem
            //    });
            //}

    //private async void OnEditMediaItemClicked(object sender, EventArgs e)
    //{
    //    {
    //        var button = (Button)sender;
    //        var selectedItem = (MediaItem)button.CommandParameter;

    //        // Creăm pagina de editare
    //        var editPage = new AddMediaItemPage();

    //        // Îi dăm paginii datele salvate anterior
    //        editPage.BindingContext = selectedItem;

    //        // Navigăm către ea
    //        await Navigation.PushAsync(editPage);
    //    }

        //private async void OnEditMediaItemClicked(object sender, EventArgs e)
        //{
        //    var menuItem = sender as MenuItem;
        //    var mediaItem = menuItem?.BindingContext as MediaItem;
        //    if (mediaItem != null)
        //    {
        //        await Navigation.PushAsync(new EditMediaItemPage(mediaItem));
        //    }
        //}
    
}
