using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VGtime.Models
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