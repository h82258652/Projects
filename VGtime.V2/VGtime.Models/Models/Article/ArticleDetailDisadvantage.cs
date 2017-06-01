using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetailDisadvantage
    {
        [JsonProperty("defect")]
        public string Defect
        {
            get;
            set;
        }
    }
}