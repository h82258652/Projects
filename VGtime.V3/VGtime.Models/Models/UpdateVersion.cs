using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class UpdateVersion
    {
        [JsonProperty("comp")]
        public int Comp
        {
            get;
            set;
        }

        [JsonProperty("content")]
        public string Content
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