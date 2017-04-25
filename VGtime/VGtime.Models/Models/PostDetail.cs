using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PostDetail
    {
        [JsonProperty("postDetail")]
        public Temp Data
        {
            get;
            set;
        }
    }
}