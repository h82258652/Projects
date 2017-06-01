using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class ClubTag
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
    }
}