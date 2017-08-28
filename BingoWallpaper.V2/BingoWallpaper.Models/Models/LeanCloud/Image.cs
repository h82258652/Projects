using Newtonsoft.Json;

namespace BingoWallpaper.Models.LeanCloud
{
    [JsonObject]
    public class Image : AVObject
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("urlbase")]
        public string UrlBase
        {
            get;
            set;
        }

        [JsonProperty("wp")]
        public bool ExistWUXGA
        {
            get;
            set;
        }
    }
}