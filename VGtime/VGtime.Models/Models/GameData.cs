using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class GameData
    {
        [JsonProperty("game")]
        public Game Data
        {
            get;
            set;
        }
    }
}