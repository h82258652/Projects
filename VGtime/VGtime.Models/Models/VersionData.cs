using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class VersionData
    {
        [JsonProperty("version")]
        public Version Data
        {
            get;
            set;
        }
    }
}