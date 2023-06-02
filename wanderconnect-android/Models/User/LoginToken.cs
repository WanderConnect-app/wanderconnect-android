using System;
using System.Text.Json.Serialization;

namespace wanderconnect_android.Models.User
{
	public class LoginToken
	{
		[JsonPropertyName("user_email")]
		public string UserEmail { get; set; } = null!;

		[JsonPropertyName("register_as")]
		public string RegisterAs { get; set; } = null!;

        [JsonPropertyName("access_token")]
		public string AccessToken { get; set; } = null!;

        [JsonPropertyName("show_ads")]
		public bool ShowAds { get; set; }
	}
}

