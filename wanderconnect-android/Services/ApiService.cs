using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using wanderconnect_android.Models.Location;
using wanderconnect_android.Models.User;
using wanderconnect_android.Pages;

namespace wanderconnect_android.Services
{
	public class ApiService
	{
        private static HttpClient _httpClient = new HttpClient();
        private static string _baseAddress = "https://wanderconnectapp01.azurewebsites.net";
        private static string _url = $"{_baseAddress}/api";
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public async void Logout()
        {
            Application.Current.MainPage = new CustomTabbedPage();
        }


        public static async Task<int> LoginUser(string emailAddress, string password)
		{
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return 1;
            }

            // create login request
            Login login = new Login
            {
                Email = emailAddress,
                Password = password,
            };

            try
            {
                string jsonUserLogin = JsonSerializer.Serialize<Login>(login, ApiService._jsonSerializerOptions);
                StringContent content = new StringContent(jsonUserLogin, Encoding.UTF8, "application/json");

                var _targetUrl = $"{ApiService._url}/User/Login";

                Debug.WriteLine(_targetUrl);
                Debug.WriteLine(content.ToString());

                HttpResponseMessage response = await ApiService._httpClient.PostAsync(_targetUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<LoginToken>(jsonResult);
                    Preferences.Set("accesstoken", result.AccessToken);
                    Preferences.Set("username", result.UserEmail.Split('@')[0]);
                    Preferences.Set("registeras", result.RegisterAs);

                    return 0;
                }
                else
                {
                    Debug.WriteLine("---> Incorrect login details");
                    return 2;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception handled: {ex.Message}");
                return 3;
            }
        }

        public static async Task<List<Category>> GetCategoryAsync()
        {
            var response = await ApiService._httpClient.GetStringAsync(ApiService._url + "/propertycategory");
            var result = JsonSerializer.Deserialize<List<Category>>(response);
            return result;
        }
	}
}

