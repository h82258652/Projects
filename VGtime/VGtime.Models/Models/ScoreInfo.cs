using System;
using Newtonsoft.Json;
using VGtime.Models.JsonConverters;

namespace VGtime.Models
{
    [JsonObject]
    public class ScoreInfo
    {
        [JsonProperty("user")]
        public UserBase User
        {
            get;
            set;
        }

        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        [JsonProperty("publishDate")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset PublishDate
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public int? Score
        {
            get;
            set;
        }
    }
}