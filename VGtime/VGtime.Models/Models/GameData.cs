using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class GameData
    {
        [JsonProperty("game")]
        public GameBase Data
        {
            get;
            set;
        }
    }
}