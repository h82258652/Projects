using System;
using Newtonsoft.Json;
using VGtime.Models.Games;
using VGtime.Models.JsonConverters;
using VGtime.Models.Users;

namespace VGtime.Models.Timeline
{
    [JsonObject]
    public class TimeLineBase
    {
        [JsonProperty("action")]
        public TimeLineAction Action
        {
            get;
            set;
        }

        [JsonProperty("advertising")]
        public Advertising Advertising
        {
            get;
            set;
        }

        [JsonProperty("category")]
        public string Category
        {
            get;
            set;
        }

        [JsonProperty("comment")]
        public TimeLineBase Comment
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

        [JsonProperty("content")]
        public string Content
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

        [JsonProperty("duration")]
        public string Duration
        {
            get;
            set;
        }

        [JsonProperty("game")]
        public GameBase Game
        {
            get;
            set;
        }

        [JsonProperty("images")]
        public TimeLineImage[] Images
        {
            get;
            set;
        }

        [JsonProperty("isFavorited")]
        public bool IsFavorited
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

        [JsonProperty("isShort")]
        public bool IsShort
        {
            get;
            set;
        }

        [JsonProperty("isVideo")]
        public bool IsVideo
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

        [JsonProperty("originalPost")]
        public TimeLineBase OriginalPost
        {
            get;
            set;
        }

        [JsonProperty("postId")]
        public int PostId
        {
            get;
            set;
        }

        [JsonProperty("publishDate")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset? PublishDate
        {
            get;
            set;
        }

        [JsonProperty("relatedGame")]
        public GameBase[] RelatedGame
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

        [JsonProperty("reviewScore")]
        public float? ReviewScore
        {
            get;
            set;
        }

        [JsonProperty("shareNum")]
        public int ShareNum
        {
            get;
            set;
        }

        [JsonProperty("shareUrl")]
        public string ShareUrl
        {
            get;
            set;
        }

        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }

        [JsonProperty("thumbnail")]
        public TimeLineImage Thumbnail
        {
            get;
            set;
        }

        [JsonProperty("timeLineType")]
        public int TimeLineType
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
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