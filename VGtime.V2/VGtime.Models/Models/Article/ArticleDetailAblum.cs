using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailAblum
    {
        [JsonProperty("cover")]
        public string Cover
        {
            get;
            set;
        }

        [JsonProperty("imgCount")]
        public int ImgCount
        {
            get;
            set;
        }

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
    }
}