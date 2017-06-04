using System;
using Newtonsoft.Json;
using VGtime.Models.JsonConverters;
using VGtime.Models.Users;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class GameScore
    {
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
        public float? Score
        {
            get;
            set;
        }

        [JsonProperty("user")]
        public UserBase User
        {
            get;
            set;
        }
    }
}