using Newtonsoft.Json;
using VGtime.Models.Article;

namespace VGtime.Models
{
    [JsonObject]
    public class PostDetail
    {
        [JsonProperty("postDetail")]
        public ArticleDetail Data
        {
            get;
            set;
        }
    }
}