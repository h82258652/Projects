using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PostStatus
    {
        [JsonProperty("postStatus")]
        public PostStatusData Data
        {
            get;
            set;
        }
    }
}