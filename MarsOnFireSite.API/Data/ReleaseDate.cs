using System.Text.Json.Serialization;

namespace MarsOnFireSite.API.Data
{
    public class ReleaseDate
    {
        [JsonPropertyName("coming_soon")]
        public bool ComingSoon { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
