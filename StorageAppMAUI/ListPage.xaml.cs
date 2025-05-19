using System.Diagnostics;
using StorageAppMAUI.Models;
using StorageAppMAUI.Services;
namespace StorageAppMAUI;

public partial class ListPage : ContentPage
{
    private readonly DatabaseService _database;
    private readonly IServiceProvider _services;

    public ListPage(IServiceProvider services, DatabaseService db)
    {
        InitializeComponent();
        _database = db;
        _services = services;
    }

    protected override async void OnAppearing()
    {
        try
        {
            base.OnAppearing();
            var items = await _database.GetObjectAsync();

            ObjectListView.ItemsSource = items;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to load objects: {ex.Message}");
            await DisplayAlert("Error", "Failed to load objects.", "OK");
        }
    }

    private async void OnAddObjectClicked(object sender, EventArgs e)
    {
        try
        {
            var newObject = new StoredObject { Name = $"Default Object {DateTime.Now}", };
            await _database.SaveObjectAsync(newObject);

            OnAppearing(); // Refresh the list
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to add object: {ex.Message}");
            await DisplayAlert("Error", $"Failed to add object. {ex.Message}", "OK");
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var storedObject = (StoredObject)button.CommandParameter;

        bool confirm = await DisplayAlert("Delete", $"Are you sure you want to delete {storedObject.Name}?", "Yes", "No");
        if (confirm)
        {
            await _database.DeleteObjectAsync(storedObject);
            OnAppearing(); // Refresh list
        }
    }

    private void OnObjectTapped(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is StoredObject storedObject)
        {
            NavigateToDetails(storedObject);
        }
    }
    private async void NavigateToDetails(StoredObject storedObject)
    {
        try
        {
            await Navigation.PushAsync(new DetailedObject(storedObject));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[NAVIGATION ERROR] {ex}");
            Console.WriteLine($"[ERROR] Navigation failed: {ex.Message}");
        }
    }
}
