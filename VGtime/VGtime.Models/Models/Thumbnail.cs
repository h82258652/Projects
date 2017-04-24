using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Thumbnail
    {
        [JsonProperty("width")]
        public int Width
        {
            get;
            set;
        }

        [JsonProperty("height")]
        public int Height
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