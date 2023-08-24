﻿using Microsoft.Extensions.Logging;
using UI.Services;
using UI.ViewModel;
namespace UI
{
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
			builder.Services.AddSingleton<PlantService>();
			builder.Services.AddSingleton<PlantViewModel>();
#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}