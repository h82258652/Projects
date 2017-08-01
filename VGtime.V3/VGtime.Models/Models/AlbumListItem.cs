using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AlbumListItem
    {
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

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
    }
}