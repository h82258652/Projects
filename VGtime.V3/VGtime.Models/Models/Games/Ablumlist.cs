using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class Ablumlist
    {
        [JsonProperty("ablumList")]
        public GameAlbum[] Data
        {
            get;
            set;
        }
    }
}