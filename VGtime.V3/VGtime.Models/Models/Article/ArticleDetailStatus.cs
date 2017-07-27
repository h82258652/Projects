using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailStatus
    {
        [JsonProperty("commentNum")]
        public int CommentNum
        {
            get;
            set;
        }

        [JsonProperty("isFavorited")]
        public bool IsFavorited
        {
            get;
            set;
        }

        [JsonProperty("isLiked")]
        public bool IsLiked
        {
            get;
            set;
        }

        [JsonProperty("likeNum")]
        public int LikeNum
        {
            get;
            set;
        }

        [JsonProperty("relation")]
        public int Relation
        {
            get;
            set;
        }

        [JsonProperty("shareNum")]
        public int ShareNum
        {
            get;
            set;
        }
    }
}