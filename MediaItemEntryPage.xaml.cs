using AnimeMangaTrackerMAUI.Models;

namespace AnimeMangaTrackerMAUI;

public partial class MediaItemEntryPage : ContentPage
{
    public MediaItemEntryPage()
    {
        InitializeComponent();
    }

    // Metoda care salvează tot ce ai scris/modificat
    async void OnSaveClicked(object sender, EventArgs e)
    {
        var item = (MediaItem)BindingContext;
        if (item != null && !string.IsNullOrWhiteSpace(item.Title))
        {
            await App.Database.SaveMediaItemAsync(item);
            await Navigation.PopAsync(); // Ne întoarcem la listă
        }
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

    // Forțează UI-ul să "vadă" noile cifre
    private void RefreshBinding()
    {
        var temp = BindingContext;
        BindingContext = null;
        BindingContext = temp;
    }
}