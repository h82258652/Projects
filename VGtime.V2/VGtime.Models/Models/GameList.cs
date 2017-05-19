using Newtonsoft.Json;
using VGtime.Models.Games;

namespace VGtime.Models
{
    [JsonObject]
    public class GameList
    {
        [JsonProperty("gameList")]
        public GameScore[] Data
        {
            get;
            set;
        }
    }
}