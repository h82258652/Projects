using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Anchor
    {
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty("page")]
        public int Page
        {
            get;
            set;
        }

        [JsonProperty("num")]
        public int Num
        {
            get;
            set;
        }
    }
}