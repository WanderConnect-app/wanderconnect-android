using System.Diagnostics;
using wanderconnect_android.Models.Location;
using wanderconnect_android.Services;

namespace wanderconnect_android.Pages.Tabs;

public partial class HomePage : ContentPage
{
	// geolocation
	private CancellationTokenSource _cancelTokenSource;
	private bool _isCheckingLocation;

	public HomePage()
	{
		InitializeComponent();

		Lbl_Username.Text = "Hi, "
			+ Preferences.Get("username", string.Empty)
			+ "!";

		// get categories
		GetCategoriesAsync();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // geolocation
        await GetCurrentLocation();
    }

    private async void GetCategoriesAsync()
    {
		var categories = await ApiService.GetCategoryAsync();
		Cv_Experiences.ItemsSource = categories;
    }

    void Cv_Experiences_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
		var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
		if (currentSelection == null) return;
    }

    // geolocation
    public async Task GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                Debug.WriteLine($"---> Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            else
                Debug.WriteLine("---> No geo location");
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }
}
