﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using wanderconnect_android.DataServices;
using wanderconnect_android.Pages.Popups;

namespace wanderconnect_android;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// dependancy injection
		builder.Services.AddSingleton<IRestDataService, RestDataService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<RegisterPopupPage>();

		return builder.Build();
	}
}

