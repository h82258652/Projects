using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AblumList
    {
        [JsonProperty("ablumnList")]
        public Ablum[] Data
        {
            get;
            set;
        }
    }
}