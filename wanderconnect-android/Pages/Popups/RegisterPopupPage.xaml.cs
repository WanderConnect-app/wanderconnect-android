using CommunityToolkit.Maui.Views;

namespace wanderconnect_android.Pages.Popups;

public partial class RegisterPopupPage : Popup
{
	public RegisterPopupPage()
	{
		InitializeComponent();
	}

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }

    void Btn_Register_ClickedAsync(System.Object sender, System.EventArgs e)
    {
        //await Navigation.PopToRootAsync();
        Close();
    }
}
