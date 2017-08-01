using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Program
    {
        [JsonProperty("cover")]
        public string Cover
        {
            get;
            set;
        }

        [JsonProperty("detailType")]
        public int DetailType
        {
            get;
            set;
        }

        [JsonProperty("duration")]
        public string Duration
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("preDate")]
        public string PreDate
        {
            get;
            set;
        }

        [JsonProperty("preTime")]
        public string PreTime
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
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