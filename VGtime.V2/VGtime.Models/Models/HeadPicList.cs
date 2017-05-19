using Newtonsoft.Json;
using VGtime.Models.Timeline;

namespace VGtime.Models
{
    [JsonObject]
    public class HeadPicList
    {
        [JsonProperty("headPicList")]
        public TimeLineBase[] Data
        {
            get;
            set;
        }
    }
}