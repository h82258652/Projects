using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PushList
    {
        [JsonProperty("pushList")]
        public Post[] Data
        {
            get;
            set;
        }
    }
}