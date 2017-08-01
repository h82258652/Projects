using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class OperationStrategy
    {
        [JsonProperty("content")]
        public OperationStrategyItem[] Content
        {
            get;
            set;
        }

        [JsonProperty("opname")]
        public string Opname
        {
            get;
            set;
        }
    }
}