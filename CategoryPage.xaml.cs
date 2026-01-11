using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();

		BindingContext = new Category();

    }
	protected override async void OnAppearing()
	{
		base.OnAppearing();
        await RefreshList();
    }

    private async Task RefreshList()
    {
        try
        {
            // Obținem datele din baza de date definită în App.xaml.cs
            listView.ItemsSource = await App.Database.GetCategoriesAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"Nu s-au putut încărca categoriile: {ex.Message}", "OK");
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
	{

        var category = (Category)BindingContext;

        if (!string.IsNullOrWhiteSpace(category.Name))
        {
            try
            {
                await App.Database.SaveCategoryAsync(category);
                BindingContext = new Category();
                listView.ItemsSource = await App.Database.GetCategoriesAsync();
            }
            catch (SQLite.SQLiteException ex) when (ex.Message.Contains("Unique"))
            {
                await DisplayAlert("Eroare: ", "Aceasta categorie exista deja in lista!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Eoare", "A aparut o problema: " + ex.Message, "OK");
            }
       
            BindingContext = new Category();
            await RefreshList();
        }
        else
        {
            await DisplayAlert("Atenție", "Numele categoriei este obligatoriu!", "OK");
        }
    }

	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
        var category = (Category)BindingContext;

        if (category.Id != 0)
        {
            bool answer = await DisplayAlert("Confirmare", $"Ștergi categoria {category.Name}?", "Da", "Nu");
            if (answer)
            {
                await App.Database.DeleteCategoryAsync(category);
                BindingContext = new Category();
                await RefreshList();
            }
        }
    }

	async void OnCategoryViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
        if (e.SelectedItem != null)
        {
            BindingContext = e.SelectedItem as Category;
        }
    }
}