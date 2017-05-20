using Newtonsoft.Json;
using VGtime.Models.Timeline;

namespace VGtime.Models
{
    [JsonObject]
    public class TopicList
    {
        [JsonProperty("topicList")]
        public TimeLineBase[] Data
        {
            get;
            set;
        }
    }
}