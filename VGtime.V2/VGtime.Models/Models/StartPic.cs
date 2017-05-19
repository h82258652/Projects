using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class StartPic
    {
        [JsonProperty("startPicture")]
        public string StartPicture
        {
            get;
            set;
        }
    }
}