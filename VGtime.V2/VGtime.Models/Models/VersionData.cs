using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class VersionData
    {
        [JsonProperty("version")]
        public Version Version
        {
            get;
            set;
        }
    }
}