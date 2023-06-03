using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using wanderconnect_android.Models.Location;
using wanderconnect_android.Models.User;

namespace wanderconnect_android.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = "https://4e47-101-179-196-59.ngrok-free.app";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<TopPick>> GetTopPicksAsync(string latitude, string longitude)
        {
            List<TopPick> topPicks = new List<TopPick>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return topPicks;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/toppicks/{latitude}/{longitude}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    topPicks = JsonSerializer.Deserialize<List<TopPick>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx Response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return topPicks;
        }

        public async Task ResetUserPassword(string emailAddress)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            // create ResetPassword
            ResetPassword resetPassword = new ResetPassword { EmailAddress = emailAddress };

            try
            {
                string jsonResetPassword = JsonSerializer.Serialize<ResetPassword>(resetPassword, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonResetPassword, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/user/resetpassword", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully requested password reset");
                }
                else
                {
                    Debug.WriteLine("---> Password reset failed");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return;
        }

        public async Task<int> LoginUser(string emailAddress, string password)
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
                string jsonUserLogin = JsonSerializer.Serialize<Login>(login, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonUserLogin, Encoding.UTF8, "application/json");

                var _targetUrl = $"{_url}/User/Login";

                Debug.WriteLine(_targetUrl);
                Debug.WriteLine(content.ToString());

                HttpResponseMessage response = await _httpClient.PostAsync(_targetUrl, content);

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
    }
}

