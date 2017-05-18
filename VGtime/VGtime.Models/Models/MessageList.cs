using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class MessageList
    {
        [JsonProperty("commentNum")]
        public int CommentNum
        {
            get;
            set;
        }

        [JsonProperty("systemNum")]
        public int SystemNum
        {
            get;
            set;
        }

        [JsonProperty("contactList")]
        public MessageBase[] ContactList
        {
            get;
            set;
        }

        [JsonProperty("likeNum")]
        public int LikeNum
        {
            get;
            set;
        }

        [JsonProperty("followerNum")]
        public int FollowerNum
        {
            get;
            set;
        }

        [JsonProperty("atNum")]
        public int AtNum
        {
            get;
            set;
        }
    }
}