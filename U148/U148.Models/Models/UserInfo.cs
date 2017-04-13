using Newtonsoft.Json;

namespace U148.Models
{
    [JsonObject]
    public class UserInfo
    {
        [JsonProperty("icon")]
        public string Icon
        {
            get;
            set;
        }

        [JsonProperty("nickname")]
        public string Nickname
        {
            get;
            set;
        }

        [JsonProperty("sex")]
        public Gender Gender
        {
            get;
            set;
        }

        [JsonProperty("token")]
        public string Token
        {
            get;
            set;
        }
    }
}