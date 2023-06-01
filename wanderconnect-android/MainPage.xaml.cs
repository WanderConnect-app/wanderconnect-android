using wanderconnect_android.DataServices;

namespace wanderconnect_android;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public MainPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;
	}

	// OnAppearing() does all the lifting when the page loads in the background, for example, getting the current location
	protected async override void OnAppearing()
	{
		base.OnAppearing();
	}
}


