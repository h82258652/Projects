using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailAnchor
    {
        [JsonProperty("num")]
        public int Num
        {
            get;
            set;
        }

        [JsonProperty("page")]
        public int Page
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