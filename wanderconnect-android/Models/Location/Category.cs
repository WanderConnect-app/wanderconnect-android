using System;
using System.Text.Json.Serialization;

namespace wanderconnect_android.Models.Location
{
	public class Category
	{
		[JsonIgnore]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("photoUrl")]
		public string? PhotoUrl { get; set; }

		[JsonPropertyName("hasPhoto")]
		public bool HasPhoto { get; set; }
	}
}

