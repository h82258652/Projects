using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class GameStrategy
    {
        [JsonProperty("items")]
        public GameStrategyItem[] Items
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
    }
}