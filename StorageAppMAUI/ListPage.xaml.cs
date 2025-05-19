using System.Diagnostics;
using StorageAppMAUI.Models;
using StorageAppMAUI.Services;
namespace StorageAppMAUI;

public partial class ListPage : ContentPage
{
    private readonly DatabaseService _database;

    public ListPage(DatabaseService db)
    {
        InitializeComponent();
        _database = db;
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
            var newObject = new StoredObject { Name = $"Default Object {DateTime.Now}",};
            await _database.SaveObjectAsync(newObject);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to add object: {ex.Message}");
            await DisplayAlert("Error", $"Failed to add object. {ex.Message}", "OK");
        }
    }
}
