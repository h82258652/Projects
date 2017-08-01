using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Badge
    {
        [JsonProperty("cover")]
        public string Cover
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

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("publishDate")]
        public string PublishDate
        {
            get;
            set;
        }

        [JsonProperty("remark")]
        public string Remark
        {
            get;
            set;
        }

    }
}
