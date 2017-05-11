using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class StrategyList
    {
        [JsonProperty("strategyList")]
        public Strategy[] Data
        {
            get;
            set;
        }
    }
}