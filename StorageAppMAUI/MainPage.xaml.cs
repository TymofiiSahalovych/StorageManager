using System.Diagnostics;

namespace StorageAppMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly IServiceProvider _services;

	public MainPage(IServiceProvider services)
	{
		InitializeComponent();
		_services = services;
	}

	private async void OnGoToListClicked(object sender, EventArgs e)
    {
		try
		{
			var listPage = _services.GetService<ListPage>();
        	await Navigation.PushAsync(listPage);
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"[NAVIGATION ERROR] {ex}");
			Console.WriteLine($"[ERROR] Navigation failed: {ex.Message}");
		}
    }
}

