using System;
using System.Text.Json.Serialization;

namespace wanderconnect_android.Models.Location
{
	public class TopPlacesByGps
	{
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public string TopPickName => Name;

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("ratingsTotal")]
        public int RatingsTotal { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        public string TopPickRating => Rating.ToString();

        [JsonPropertyName("priceLevel")]
        public int PriceLevel { get; set; }

        [JsonPropertyName("vicinity")]
        public string Vicinity { get; set; }

        public string TopPickVicinity => Vicinity;

        [JsonPropertyName("placeType")]
        public string PlaceType { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("placeId")]
        public string PlaceId { get; set; }

        [JsonPropertyName("imagePath")]
        public string ImagePath { get; set; }

        public string TopPickImagePage => ImagePath;
    }
}

