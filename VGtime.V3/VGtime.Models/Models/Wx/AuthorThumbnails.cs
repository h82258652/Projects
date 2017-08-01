using Newtonsoft.Json;

namespace VGtime.Models.Wx
{
    [JsonObject]
    public class AuthorThumbnails
    {
        [JsonProperty("extralarge")]
        public string Extralarge
        {
            get;
            set;
        }

        [JsonProperty("large")]
        public string Large
        {
            get;
            set;
        }

        [JsonProperty("medium")]
        public string Medium
        {
            get;
            set;
        }

        [JsonProperty("small")]
        public string Small
        {
            get;
            set;
        }
    }
}