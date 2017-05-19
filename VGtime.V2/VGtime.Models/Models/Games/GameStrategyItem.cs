using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class GameStrategyItem
    {
        [JsonProperty("detailType")]
        public int DetailType
        {
            get;
            set;
        }

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
    }
}