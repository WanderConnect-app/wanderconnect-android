using System.Diagnostics;

namespace wanderconnect_android.Pages.Tabs;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    async void TapLogout_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        bool result = await OnAlertYesNoClicked(sender = null, e = null);

        if (result)
        {
            Preferences.Clear();
            Application.Current.MainPage = new CustomMainPage();
            await Navigation.PopToRootAsync();
        }
    }

    async Task<bool> OnAlertYesNoClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirm Logout", "Are you sure you want to logout?", "Yes", "No");
        Debug.WriteLine("Answer: " + answer);

        return answer;
    }
}
