using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PostDetail
    {
        [JsonProperty("postDetail")]
        public Post Data
        {
            get;
            set;
        }
    }
}