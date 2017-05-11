using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class StrategyItem
    {
        [JsonProperty("postId")]
        public int PostId
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty("detailType")]
        public int DetailType
        {
            get;
            set;
        }
    }
}