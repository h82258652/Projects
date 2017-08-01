using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class OperationStrategyItem
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }
    }
}