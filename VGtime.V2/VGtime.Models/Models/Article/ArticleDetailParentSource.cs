using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailParentSource
    {
        [JsonProperty("commentNum")]
        public int CommentNum
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