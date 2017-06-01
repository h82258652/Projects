using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailAdvantage
    {
        [JsonProperty("merit")]
        public string Merit
        {
            get;
            set;
        }
    }
}