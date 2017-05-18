using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class TimeLineAction
    {
        [JsonProperty("operation")]
        public int Operation
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public float Score
        {
            get;
            set;
        }

        [JsonProperty("comment")]
        public string Comment
        {
            get;
            set;
        }
    }
}