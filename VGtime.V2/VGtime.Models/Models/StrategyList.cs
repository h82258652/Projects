using Newtonsoft.Json;
using VGtime.Models.Games;

namespace VGtime.Models
{
    [JsonObject]
    public class StrategyList
    {
        [JsonProperty("strategyList")]
        public GameStrategy[] Data
        {
            get;
            set;
        }
    }
}