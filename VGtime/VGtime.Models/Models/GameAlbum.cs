using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class GameAlbum
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
    }
}