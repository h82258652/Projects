using Newtonsoft.Json;
using VGtime.Models.Games;

namespace VGtime.Models
{
    [JsonObject]
    public class GameData
    {
        [JsonProperty("game")]
        public GameBase Game
        {
            get;
            set;
        }
    }
}