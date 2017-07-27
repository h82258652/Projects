using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailIndex
    {
        [JsonProperty("index")]
        public int Index
        {
            get;
            set;
        }

        [JsonProperty("isPressed")]
        public bool IsPressed
        {
            get;
            set;
        }
    }
}