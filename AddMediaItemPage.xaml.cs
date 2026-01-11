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

    // Butonul de PLUS (+)
    void OnIncrementClicked(object sender, EventArgs e)
    {
        var item = (MediaItem)BindingContext;
        if (item != null)
        {
            item.Progress++;
            RefreshBinding(); // ASTA face ca cifrele să se schimbe pe ecran
        }
    }

    // Butonul de MINUS (-)
    void OnDecrementClicked(object sender, EventArgs e)
    {
        var item = (MediaItem)BindingContext;
        if (item != null && item.Progress > 0)
        {
            item.Progress--;
            RefreshBinding();
        }
    }

    private void RefreshBinding()
    {
        var temp = BindingContext;
        BindingContext = null;
        BindingContext = temp;
    }
}
