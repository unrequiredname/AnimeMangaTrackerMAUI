using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI;

public partial class EditMediaItemPage : ContentPage
{
	public EditMediaItemPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		BindingContext = new MediaItem();
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