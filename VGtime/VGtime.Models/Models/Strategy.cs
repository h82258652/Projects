using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Strategy
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public int Type
        {
            get;
            set;
        }

        [JsonProperty("items")]
        public StrategyItem[] Items
        {
            get;
            set;
        }
    }
}