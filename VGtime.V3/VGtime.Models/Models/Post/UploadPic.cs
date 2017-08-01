using Newtonsoft.Json;

namespace VGtime.Models.Post
{
    [JsonObject]
    public class UploadPic
    {
        [JsonProperty("size")]
        public string Size
        {
            get;
            set;
        }

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
    }
}