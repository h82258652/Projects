using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailVote
    {
        [JsonProperty("name")]
        public string Name
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

        [JsonProperty("userCount")]
        public int UserCount
        {
            get;
            set;
        }
    }
}