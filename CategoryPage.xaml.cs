using AnimeMangaTrackerMAUI.Models;
using System.Diagnostics;

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

        try
        {

            var categories = await App.Database.GetCategoriesAsync();
            listView.ItemsSource = categories;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Eroare la încărcare: {ex.Message}");
            await DisplayAlert("Eroare", "Nu s-a putut accesa baza de date.", "OK");
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var category = (Category)BindingContext;

        if (string.IsNullOrWhiteSpace(category.Name))
        {
            await DisplayAlert("Atenție", "Numele categoriei nu poate fi gol!", "OK");
            return;
        }

        await App.Database.SaveCategoryAsync(category);

        BindingContext = new Category();

        listView.ItemsSource = await App.Database.GetCategoriesAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var category = (Category)BindingContext;

        if (category != null && category.Id != 0)
        {
            bool confirm = await DisplayAlert("Confirmare", $"Ștergi categoria {category.Name}?", "Da", "Nu");
            if (confirm)
            {
                await App.Database.DeleteCategoryAsync(category);
                BindingContext = new Category();
                listView.ItemsSource = await App.Database.GetCategoriesAsync();
            }
        }
        else
        {
            await DisplayAlert("Info", "Selectează o categorie din listă pentru a o șterge.", "OK");
        }
    }

    void OnCategoryViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            BindingContext = e.SelectedItem as Category;
        }
    }
}