using System;
using System.Text.Json.Serialization;

namespace wanderconnect_android.Models.Location
{
	public class TopRatedDto
	{
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("placeId")]
        public string PlaceId { get; set; }

        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }
    }
}

