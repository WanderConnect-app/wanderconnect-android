using wanderconnect_android.DataServices;
using wanderconnect_android.Pages;

namespace wanderconnect_android;

public partial class App : Application
{
    private readonly IRestDataService restDataService;

    public App()
	{
		InitializeComponent();

        // Injected instance of IRestDataService, or use a default implementation if not provided
        this.restDataService = restDataService ?? new RestDataService();

        //MainPage = new AppShell();
        //MainPage = new CustomMainPage(dataService: restDataService = null);
        MainPage = new CustomMainPage();
	}
}

