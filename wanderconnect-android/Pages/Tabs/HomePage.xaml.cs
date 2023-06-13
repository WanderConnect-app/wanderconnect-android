using System.Diagnostics;
using wanderconnect_android.Models.Location;
using wanderconnect_android.Services;
using static Android.Provider.MediaStore.Audio;

namespace wanderconnect_android.Pages.Tabs;

public partial class HomePage : ContentPage
{
	// geolocation
	private CancellationTokenSource _cancelTokenSource;
	private bool _isCheckingLocation;

    private string _latitude = string.Empty;
    private string _longitude = string.Empty;

	public HomePage()
	{
		InitializeComponent();

		Lbl_Username.Text = "Hi, "
			+ Preferences.Get("username", string.Empty)
			+ "!";

		// get categories
		GetCategoriesAsync();

        InitializePageAsync();



        //// create top picks dummy data
        //List<CvTopPicksList> topPicksLists = new List<CvTopPicksList>
        //{
        //    new CvTopPicksList
        //    {
        //        ImagePath = "https://wcs3blobeus.blob.core.windows.net/museum/ChIJlwsH0RWuEmsR3Cg3WEDw76I.jpg",
        //        Name = "Australian Museum",
        //        Vicinity = "1 William Street, Darlinghurst",
        //        Rating = 4.6
        //    },
        //    new CvTopPicksList
        //    {
        //        ImagePath = "https://wcs3blobeus.blob.core.windows.net/wc-api/no-image-available.jpg",
        //        Name = "Oblong Design",
        //        Vicinity = "117 Reservoir Street, Surry Hills",
        //        Rating = 0
        //    },
        //    new CvTopPicksList
        //    {
        //        ImagePath = "https://wcs3blobeus.blob.core.windows.net/museum/ChIJx5OOkhOuEmsR3S-z27E229c.jpg",
        //        Name = "Sydney Jewish Museum",
        //        Vicinity = "148 Darlinghurst Road, Darlinghurst",
        //        Rating = 4.6
        //    },
        //    new CvTopPicksList
        //    {
        //        ImagePath = "https://wcs3blobeus.blob.core.windows.net/museum/ChIJJRFbvAWuEmsRSsERIb7WbLs.jpg",
        //        Name = "Australian Museum of Magical Arts",
        //        Vicinity = "91 Riley Street, Darlinghurst",
        //        Rating = 4.6
        //    },
        //    new CvTopPicksList {
        //        ImagePath = "https://wcs3blobeus.blob.core.windows.net/museum/ChIJlwsH0RWuEmsR3Cg3WEDw76I.jpg",
        //        Name = "Australian Museum",
        //        Vicinity = "1 William Street, Darlinghurst",
        //        Rating = 4.3
        //    },
        //};

        //Cv_TopPicks.ItemsSource = topPicksLists;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async Task InitializePageAsync()
    {
        // geolocation <- get the current location of the user
        await GetCurrentLocation();

        await GetTopPlacesAsync();
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
            {
                Debug.WriteLine($"---> Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                // set geolocation data
                _latitude = location.Latitude.ToString();
                _longitude = location.Longitude.ToString();
            }
            else
            {
                Debug.WriteLine("---> No geo location");
            }
                
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
            Debug.WriteLine(ex.Message);
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public async Task GetTopPlacesAsync()
    {
        List<TopRatedDto> topRatedDtos = await ApiService.Get10TopRatedPlacesAsync();
        Cv_TopPicks.ItemsSource = topRatedDtos;
    }

    //public async Task GetCurrentLocationTopPlacesAsync()
    //{
    //    int _radius = 10000;
    //    List<TopPlacesByGps> topPlacesByGps = await ApiService.GetTopPlacesAsync(latitude: _latitude, longitude: _longitude, radius: _radius);
    //    Debug.WriteLine($"The check data is: -------> latitude: {_latitude}, longitude: {_longitude}, radius: {_radius}");
    //    Cv_TopPicks.ItemsSource = topPlacesByGps;

    //    foreach (TopPlacesByGps t in topPlacesByGps)
    //    {
    //        Debug.WriteLine(t.ImagePath);
    //    }
    //}

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }
}


//public class CvTopPicksList
//{
//    public string ImagePath { get; set; }
//    public string Name { get; set; }
//    public string Vicinity { get; set; }
//    public double Rating { get; set; }
//}