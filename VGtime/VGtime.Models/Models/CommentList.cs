using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class CommentList
    {
        [JsonProperty("commentList")]
        public Post[] Data
        {
            get;
            set;
        }
    }
}