namespace wanderconnect_android.Pages.Tabs;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    void TapLogout_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		Preferences.Clear();

        Application.Current.MainPage = new MainPage();
        Navigation.PopToRootAsync();
    }
}
