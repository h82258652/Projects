using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class HotWord
    {
        [JsonProperty("keyword")]
        public string Keyword
        {
            get;
            set;
        }
    }
}