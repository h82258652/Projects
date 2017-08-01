using Newtonsoft.Json;

namespace VGtime.Models.Timeline
{
    [JsonObject]
    public class TimeLineImage
    {
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

        [JsonProperty("width")]
        public int Width
        {
            get;
            set;
        }
    }
}