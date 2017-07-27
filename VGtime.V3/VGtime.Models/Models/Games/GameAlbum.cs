using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class GameAlbum
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