using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI;

public partial class AddMediaItemPage : ContentPage
{
	public AddMediaItemPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

        if (BindingContext == null)
        {
            BindingContext = new MediaItem();
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e) {
        var mediaItem = (MediaItem)BindingContext;
        await App.Database.SaveMediaItemAsync(mediaItem);
        await Navigation.PopAsync();
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
 }
