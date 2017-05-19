using Newtonsoft.Json;
using VGtime.Models.Timeline;

namespace VGtime.Models
{
    [JsonObject]
    public class CommentList
    {
        [JsonProperty("commentList")]
        public TimeLineBase[] Data
        {
            get;
            set;
        }
    }
}