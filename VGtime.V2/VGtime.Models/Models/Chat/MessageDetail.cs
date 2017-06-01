using Newtonsoft.Json;
using VGtime.Models.Users;

namespace VGtime.Models.Chat
{
    [JsonObject]
    public class MessageDetail
    {
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        [JsonProperty("messageId")]
        public long MessageId
        {
            get;
            set;
        }

        [JsonProperty("sendTime")]
        public long SendTime
        {
            get;
            set;
        }

        [JsonProperty("showDate")]
        public bool ShowDate
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public bool Status
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