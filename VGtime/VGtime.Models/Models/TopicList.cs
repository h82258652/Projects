using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class TopicList
    {
        [JsonProperty("topicList")]
        public Temp[] Data
        {
            get;
            set;
        }
    }
}