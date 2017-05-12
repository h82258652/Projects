using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Ablum
    {
        [JsonProperty("id")]
        public object Id
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
    }
}