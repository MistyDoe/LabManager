using Microsoft.Extensions.Logging;
using UI.Services;
namespace UI;

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

			});
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<PlantService>();
		builder.Services.AddSingleton<PlantViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}