using System;
using Newtonsoft.Json;
using VGtime.Models.JsonConverters;

namespace VGtime.Models
{
    [JsonObject]
    public class Comment
    {
        [JsonProperty("postId")]
        public int PostId
        {
            get;
            set;
        }

        [JsonProperty("user")]
        public User User
        {
            get;
            set;
        }

        [JsonProperty("text")]
        public object Text
        {
            get;
            set;
        }

        [JsonProperty("commentNum")]
        public int CommentNum
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

        [JsonProperty("likeNum")]
        public int LikeNum
        {
            get;
            set;
        }

        [JsonProperty("isLiked")]
        public bool IsLiked
        {
            get;
            set;
        }

        [JsonProperty("remark")]
        public string Remark
        {
            get;
            set;
        }

        [JsonProperty("detailType")]
        public int DetailType
        {
            get;
            set;
        }
    }
}