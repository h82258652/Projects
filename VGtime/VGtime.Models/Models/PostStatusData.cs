using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PostStatusData
    {
        [JsonProperty("postStatus")]
        public PostStatus Data
        {
            get;
            set;
        }
    }
}