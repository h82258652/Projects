using Newtonsoft.Json;

namespace VGtime.Models.Timeline
{
    [JsonObject]
    public class TimeLineAction
    {
        [JsonProperty("comment")]
        public string Comment
        {
            get;
            set;
        }

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
    }
}