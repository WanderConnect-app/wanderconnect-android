using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using wanderconnect_android.Models.Location;
using wanderconnect_android.Models.User;
using wanderconnect_android.Pages;

namespace wanderconnect_android.Services
{
	public class GeoService
	{
        public static async Task<List<Category>> GetCategoryAsync()
        {
            var response = await ApiService._httpClient.GetStringAsync(ApiService._url + "/propertycategory");
            var result = JsonSerializer.Deserialize<List<Category>>(response);
            return result;
        }
	}
}

