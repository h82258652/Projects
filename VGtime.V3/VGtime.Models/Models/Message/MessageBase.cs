using Newtonsoft.Json;
using VGtime.Models.Chat;
using VGtime.Models.Users;

namespace VGtime.Models.Message
{
    [JsonObject]
    public class MessageBase
    {
        [JsonProperty("message")]
        public MessageDetail Message
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