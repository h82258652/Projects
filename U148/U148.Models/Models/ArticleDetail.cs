using Newtonsoft.Json;

namespace U148.Models
{
    [JsonObject]
    public class ArticleDetail
    {
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }
    }
}