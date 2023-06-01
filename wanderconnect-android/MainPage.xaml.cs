using CommunityToolkit.Maui.Views;
using wanderconnect_android.DataServices;
using wanderconnect_android.Pages.Popups;

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

    void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void RegisterAccountPopUp_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //await DisplayAlert(
        //	title: string.Empty,
        //	message: "Register account tapped",
        //	cancel: "OK");
        this.ShowPopup(new RegisterPopupPage());
    }
}


