using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using wanderconnect_android.DataServices;

namespace wanderconnect_android.Pages.Popups
{
    public partial class RegisterPopupPage : Popup
    {
        private List<string> CountryNames = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                                .Select(culture => new RegionInfo(culture.Name).EnglishName)
                                                .Distinct()
                                                .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
                                                .ToList();

        public RegisterPopupPage()
        {
            InitializeComponent();

            // Country list
            Pkr_Country.ItemsSource = CountryNames;

            Pkr_RegisterType.ItemsSource = new List<string>
            {
                "Solo Adventurer",
                "Travelling",
                "Intimate Memories",
                "Local Discoveries",
                "Personal Growth",
                "Social Networking",
                "Family Outings",
                "Good for Groups",
            };

            // Set the BindingContext to this class instance
            BindingContext = this;
        }

        void TapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
        {

        }

        async void Btn_Register_ClickedAsync(object sender, System.EventArgs e)
        {
            if (Ent_Email.Text != null
                && Ent_Email.Text != null
                && Ent_Password.Text !=null
                && Chk_AcceptTerms.IsChecked != false
                && Pkr_Country.SelectedItem != null
                && Pkr_RegisterType.SelectedItem != null)
            {
                // close the popup
                Close();
            }
            else
            {
                // Handle the case when any of the conditions are not met
                // For example, you can display an error message or perform other actions
            }
        }
    }
}
