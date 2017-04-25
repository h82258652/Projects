using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class TopicList
    {
        [JsonProperty("topicList")]
        public Post[] Data
        {
            get;
            set;
        }
    }
}