using System.Text.Json.Serialization;

namespace MarsOnFireSite.API.Data
{
    public class Price
    {
        [JsonPropertyName("final_formatted")]
        public string FormattedPrice { get; set; }
    }
}
