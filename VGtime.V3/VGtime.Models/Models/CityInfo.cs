using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class CityInfo
    {
        [JsonProperty("codeName")]
        public string CodeName
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

        [JsonProperty("pName")]
        public string PName
        {
            get;
            set;
        }

        [JsonProperty("shortName")]
        public string ShortName
        {
            get;
            set;
        }
    }
}