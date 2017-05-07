using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class SearchList
    {
        [JsonProperty("searchList")]
        public Post[] Data
        {
            get;
            set;
        }
    }
}