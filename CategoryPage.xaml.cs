using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext == null)
		{
			BindingContext = new Category();
			listView.ItemsSource = await App.Database.GetCategoriesAsync();
		}
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var category = (Category)BindingContext;
		await App.Database.SaveCategoryAsync(category);
		listView.ItemsSource = await App.Database.GetCategoriesAsync();
	}

	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var category = (Category)BindingContext;
		await App.Database.DeleteCategoryAsync(category);
		listView.ItemsSource = await App.Database.GetCategoriesAsync();
	}

	async void OnCategoryViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			await Navigation.PushAsync(new CategoryPage
			{
				BindingContext = e.SelectedItem as Category
			});

		}
	}
}