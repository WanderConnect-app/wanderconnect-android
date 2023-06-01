using System.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using wanderconnect_android.DataServices;

namespace wanderconnect_android.Pages.Popups
{
    public partial class RegisterPopupPage : Popup
    {
        public RegisterPopupPage()
        {
            InitializeComponent();

            // Set the BindingContext to this class instance
            BindingContext = this;
        }

        void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
        {

        }

        async void Btn_Register_ClickedAsync(object sender, System.EventArgs e)
        {
            // check form is filled properly
            if (Ent_Email.Text.Contains("@") == true
                && Ent_Email.Text.Length > 6
                && Ent_Password.Text.Length > 3
                && Chk_AcceptTerms.IsChecked == true)
            //&& Pkr_Country != null
            //&& Pkr_RegisterType != null

            {
                Btn_Register.IsEnabled = true;
            }
            else
            {
                return;
            }

            // close the popup
            Close();
        }
    }
}
