using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class GameList
    {
        [JsonProperty("gameList")]
        public ScoreInfo[] Data
        {
            get;
            set;
        }
    }
}