using System.Text.Json.Serialization;

namespace MarsOnFireSite.API.Data
{
    public class AppData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("release_date")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonPropertyName("price_overview")]
        public Price? Price { get; set; } = null;

        [JsonPropertyNameAttribute("header_image")]
        public string ImageUrl { get; set; }
    }
}
