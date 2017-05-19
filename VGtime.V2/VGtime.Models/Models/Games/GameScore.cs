using Newtonsoft.Json;
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
        public string PublishDate
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

        [JsonProperty("user")]
        public UserBase User
        {
            get;
            set;
        }
    }
}