using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AdData
    {
        [JsonProperty("ad")]
        public Advertising Data
        {
            get;
            set;
        }
    }
}