using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class CommentList
    {
        [JsonProperty("commentList")]
        public Temp[] Data
        {
            get;
            set;
        }
    }
}