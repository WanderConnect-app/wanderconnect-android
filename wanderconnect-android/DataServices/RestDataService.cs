using System;
using System.Diagnostics;
using System.Text.Json;
using wanderconnect_android.Models.Location;

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
            _baseAddress = "https://e6f5-101-179-196-59.ngrok-free.app";
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
    }
}

