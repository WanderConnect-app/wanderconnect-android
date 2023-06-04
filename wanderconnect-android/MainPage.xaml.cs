using CommunityToolkit.Maui.Views;
using wanderconnect_android.DataServices;
using wanderconnect_android.Pages;
using wanderconnect_android.Pages.Popups;

namespace wanderconnect_android;

public partial class MainPage : ContentPage
{
    public readonly IRestDataService _dataService;
    public Label _lblEmailError;

    public MainPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;

        var accessToken = Preferences.Get("accesstoken", string.Empty);
        if (!string.IsNullOrEmpty(accessToken))
        {
            //Application.Current.MainPage = new CustomTabbedPage();
            //Navigation.PopToRootAsync();

            Shell.Current.GoToAsync("//customtabbedpage");
        }
    }

    // OnAppearing() does all the lifting when the page loads in the background, for example, getting the current location
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    async void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        // set the accesstoken, username, registeras values and returns true if successful
        var isLogin = await _dataService.LoginUser(
                                emailAddress: EntEmail.Text.ToString().ToLower(),
                                password: EntPassword.Text.ToString().ToLower());

        switch(isLogin)
        {
            case 1:
                await DisplayAlert(
                    title: "Login Error",
                    message: "No Internet",
                    cancel: "OK");
                return;

            case 2:
                await DisplayAlert(
                    title: "Login Error",
                message: "Failed Login",
                cancel: "OK");
                return;

            case 3:
                await DisplayAlert(
                    title: "Login Error",
                    message: "Other error",
                    cancel: "OK");
                return;
        }

        if (isLogin == 0)
        {
            await Shell.Current.GoToAsync(nameof(CustomTabbedPage));
        }
    }

    void RegisterAccountPopUp_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //await DisplayAlert(
        //	title: string.Empty,
        //	message: "Register account tapped",
        //	cancel: "OK");
        this.ShowPopup(new RegisterPopupPage());
    }

    void TapForgotPassword_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.ShowPopup(new ForgotPasswordPopupPage());
    }
}

