using System.Diagnostics;
using StorageAppMAUI.Models;

namespace StorageAppMAUI;

public partial class DetailedObject : ContentPage
{
    private readonly StoredObject _storedObject;

    public DetailedObject(StoredObject storedObject)
    {
        InitializeComponent();
        _storedObject = storedObject;

        // Display data
        IdLabel.Text = _storedObject.Id.ToString();
        NameLabel.Text = _storedObject.Name;
        // DisplayAlert("Error", "Failed to load object.", "OK");
    }
}
