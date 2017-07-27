using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailGameOperation
    {
        [JsonProperty("comment")]
        public string Comment
        {
            get;
            set;
        }

        [JsonProperty("operation")]
        public int Operation
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public int Score
        {
            get;
            set;
        }
    }
}