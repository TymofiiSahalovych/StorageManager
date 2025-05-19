using Microsoft.Extensions.Logging;
using StorageAppMAUI.Services;
using System.Diagnostics;
namespace StorageAppMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register the DatabaseService as a singleton
		builder.Services.AddSingleton<DatabaseService>();
		builder.Services.AddTransient<ListPage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
