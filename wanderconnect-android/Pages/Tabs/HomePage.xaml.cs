﻿using wanderconnect_android.Models.Location;
using wanderconnect_android.Services;

namespace wanderconnect_android.Pages.Tabs;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		Lbl_Username.Text = "Hi, "
			+ Preferences.Get("username", string.Empty)
			+ "!";

		// get categories
		GetCategoriesAsync();
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
}
