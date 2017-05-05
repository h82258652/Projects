using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class StartPicture
    {
        [JsonProperty("startPicture")]
        public string Data
        {
            get;
            set;
        }
    }
}