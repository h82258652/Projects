using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class TimeLineImage
    {
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int Width
        {
            get;
            set;
        }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
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