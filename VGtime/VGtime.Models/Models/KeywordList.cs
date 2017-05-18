using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class KeywordList
    {
        [JsonProperty("keywordList")]
        public HotWord[] Data
        {
            get;
            set;
        }
    }
}