﻿using Client.Pages;
using Client.Services;
using Microsoft.Extensions.Logging;


namespace Client
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

			builder.Services.AddSingleton<IPlantRestDataServices, PlantRestDataServices>();
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddTransient<ManagePlantPage>();

			builder.Services.AddSingleton<IIngredientRestServices, IngredientRestServices>();
			builder.Services.AddSingleton<IngredientPage>();
			builder.Services.AddSingleton<ManageIngredientPage>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}