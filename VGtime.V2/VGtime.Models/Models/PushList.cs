using Newtonsoft.Json;
using VGtime.Models.Timeline;

namespace VGtime.Models
{
    [JsonObject]
    public class PushList
    {
        [JsonProperty("pushList")]
        public TimeLineBase[] Data
        {
            get;
            set;
        }
    }
}