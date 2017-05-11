using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Action
    {
        [JsonProperty("operation")]
        public int Operation
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public int Score
        {
            get;
            set;
        }

        [JsonProperty("comment")]
        public object Comment
        {
            get;
            set;
        }
    }
}