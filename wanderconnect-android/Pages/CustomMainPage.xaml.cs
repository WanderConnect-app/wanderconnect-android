using CommunityToolkit.Maui.Views;
using wanderconnect_android.DataServices;
using wanderconnect_android.Pages;
using wanderconnect_android.Pages.Popups;
using wanderconnect_android.Services;

namespace wanderconnect_android.Pages;

public partial class CustomMainPage : ContentPage
{
    public IRestDataService _dataService;
    public Label _lblEmailError;

    public CustomMainPage()
    {
        InitializeComponent();

        var accessToken = Preferences.Get("accesstoken", string.Empty);
        if (!string.IsNullOrEmpty(accessToken))
        {
            Application.Current.MainPage = new CustomTabbedPage();
            Navigation.PopToRootAsync();
        }
    }

    // OnAppearing() does all the lifting when the page loads in the background, for example, getting the current location
    protected override void OnAppearing()
    {
        base.OnAppearing();
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

    async void BtnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        // start the login animation circle thing
        AcI_Login.IsVisible = true;
        AcI_Login.IsRunning = true;

        // set the accesstoken, username, registeras values and returns true if successful
        var loginResult = await ApiService.LoginUser(emailAddress: EntEmail.Text, password: EntPassword.Text);

        //var isLogin = await _dataService.LoginUser(
        //                        emailAddress: EntEmail.Text.ToString().ToLower(),
        //                        password: EntPassword.Text.ToString().ToLower());

        switch (loginResult)
        {
            case 1:
                AcI_Login.IsVisible = false;
                AcI_Login.IsRunning = false;

                await DisplayAlert(
                    title: "Login Error",
                    message: "No Internet",
                    cancel: "OK");
                return;

            case 2:
                AcI_Login.IsVisible = false;
                AcI_Login.IsRunning = false;

                await DisplayAlert(
                    title: "Login Error",
                message: "Failed Login",
                cancel: "OK");
                return;

            case 3:
                AcI_Login.IsVisible = false;
                AcI_Login.IsRunning = false;

                await DisplayAlert(
                    title: "Login Error",
                    message: "Other error",
                    cancel: "OK");
                return;
        }

        if (loginResult == 0)
        {
            //await Shell.Current.GoToAsync(nameof(CustomTabbedPage));
            Application.Current.MainPage = new CustomTabbedPage();
        }

    }
}

