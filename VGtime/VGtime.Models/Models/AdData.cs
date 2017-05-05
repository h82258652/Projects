using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AdData
    {
        [JsonProperty("ad")]
        public Ad Data
        {
            get;
            set;
        }
    }
}