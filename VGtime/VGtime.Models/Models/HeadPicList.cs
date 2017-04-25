using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class HeadPicList
    {
        [JsonProperty("headPicList")]
        public Post[] Data
        {
            get;
            set;
        }
    }
}