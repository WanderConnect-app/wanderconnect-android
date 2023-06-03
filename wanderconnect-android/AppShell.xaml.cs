using wanderconnect_android.Pages;

namespace wanderconnect_android;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// add routes
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(CustomTabbedPage), typeof(CustomTabbedPage));
	}
}

