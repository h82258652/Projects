using System;
using Newtonsoft.Json;
using VGtime.Models.JsonConverters;

namespace VGtime.Models
{
    [JsonObject]
    public class Post
    {
        [JsonProperty("user")]
        public User User
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

        [JsonProperty("timeLineType")]
        public int TimeLineType
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

        [JsonProperty("commentNum", NullValueHandling = NullValueHandling.Ignore)]
        public int CommentNum
        {
            get;
            set;
        }

        [JsonProperty("shareNum", NullValueHandling = NullValueHandling.Ignore)]
        public int ShareNum
        {
            get;
            set;
        }

        [JsonProperty("likeNum", NullValueHandling = NullValueHandling.Ignore)]
        public int LikeNum
        {
            get;
            set;
        }

        [JsonProperty("isFavorited", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsFavorited
        {
            get;
            set;
        }

        [JsonProperty("isLiked", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsLiked
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

        [JsonProperty("images")]
        public object[] Images
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

        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail
        {
            get;
            set;
        }

        [JsonProperty("isShort", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsShort
        {
            get;
            set;
        }

        [JsonProperty("relatedGame")]
        public object RelatedGame
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

        [JsonProperty("author")]
        public string Author
        {
            get;
            set;
        }

        [JsonProperty("editor")]
        public string Editor
        {
            get;
            set;
        }

        [JsonProperty("isQuestion", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsQuestion
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

        [JsonProperty("isVideo", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsVideo
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

        [JsonProperty("duration")]
        public string Duration
        {
            get;
            set;
        }

        [JsonProperty("parentSource")]
        public object ParentSource
        {
            get;
            set;
        }

        [JsonProperty("originalPost")]
        public object OriginalPost
        {
            get;
            set;
        }

        [JsonProperty("game")]
        public object Game
        {
            get;
            set;
        }

        [JsonProperty("action")]
        public object Action
        {
            get;
            set;
        }

        [JsonProperty("comment")]
        public Post Comment
        {
            get;
            set;
        }

        [JsonProperty("detailType", NullValueHandling = NullValueHandling.Ignore)]
        public int DetailType
        {
            get;
            set;
        }

        [JsonProperty("trueType", NullValueHandling = NullValueHandling.Ignore)]
        public int TrueType
        {
            get;
            set;
        }

        [JsonProperty("ad")]
        public Ad Ad
        {
            get;
            set;
        }

        [JsonProperty("isSolve")]
        public object IsSolve
        {
            get;
            set;
        }

        [JsonProperty("advantageList")]
        public object AdvantageList
        {
            get;
            set;
        }

        [JsonProperty("disadvantageList")]
        public object DisadvantageList
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

        [JsonProperty("ablumList")]
        public object[] AblumList
        {
            get;
            set;
        }

        [JsonProperty("programList")]
        public object[] ProgramList
        {
            get;
            set;
        }

        [JsonProperty("voteList")]
        public object[] VoteList
        {
            get;
            set;
        }

        [JsonProperty("videoList")]
        public object[] VideoList
        {
            get;
            set;
        }

        [JsonProperty("contentPage", NullValueHandling = NullValueHandling.Ignore)]
        public int ContentPage
        {
            get;
            set;
        }

        [JsonProperty("anchor")]
        public object[] Anchor
        {
            get;
            set;
        }

        [JsonProperty("comments")]
        public Comment[] Comments
        {
            get;
            set;
        }

        [JsonProperty("games")]
        public object[] Games
        {
            get;
            set;
        }

        [JsonProperty("news")]
        public object[] News
        {
            get;
            set;
        }
    }
}