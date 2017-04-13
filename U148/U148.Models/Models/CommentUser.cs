using Newtonsoft.Json;

namespace U148.Models
{
    [JsonObject]
    public class CommentUser
    {
        [JsonProperty("nickname")]
        public string Nickname
        {
            get;
            set;
        }

        [JsonProperty("alias")]
        public string Alias
        {
            get;
            set;
        }

        [JsonProperty("icon")]
        public string Icon
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }
    }
}