using System.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using wanderconnect_android.DataServices;

namespace wanderconnect_android.Pages.Popups
{
    public partial class ForgotPasswordPopupPage : Popup
    {
        private readonly IRestDataService restDataService;

        public ForgotPasswordPopupPage(IRestDataService restDataService = null)
        {
            InitializeComponent();

            // Injected instance of IRestDataService, or use a default implementation if not provided
            this.restDataService = restDataService ?? new RestDataService();

            // Set the BindingContext to this class instance
            BindingContext = this;
        }

        async void Btn_ResetPassword_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Ent_Email.Text != null)
            {
                await restDataService.ResetUserPassword(emailAddress: Ent_Email.Text);
            }

            Close();
        }
    }
}
