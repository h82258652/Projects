using Newtonsoft.Json;
using VGtime.Models.Article;

namespace VGtime.Models
{
    [JsonObject]
    public class PostStatus
    {
        [JsonProperty("postStatus")]
        public ArticleDetailStatus Data
        {
            get;
            set;
        }
    }
}