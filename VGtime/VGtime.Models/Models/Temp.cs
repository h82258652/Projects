using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Temp
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
        public long PublishDate
        {
#warning it should be DateTimeOffset
            get;
            set;
        }

        [JsonProperty("commentNum")]
        public int CommentNum
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

        [JsonProperty("likeNum")]
        public int LikeNum
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

        [JsonProperty("text")]
        public object Text
        {
            get;
            set;
        }

        [JsonProperty("images")]
        public object Images
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
        public object Content
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

        [JsonProperty("isShort")]
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
        public object Author
        {
            get;
            set;
        }

        [JsonProperty("editor")]
        public object Editor
        {
            get;
            set;
        }

        [JsonProperty("isQuestion")]
        public object IsQuestion
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

        [JsonProperty("isVideo")]
        public bool IsVideo
        {
            get;
            set;
        }

        [JsonProperty("remark")]
        public object Remark
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
        public object Comment
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

        [JsonProperty("trueType")]
        public object TrueType
        {
            get;
            set;
        }

        [JsonProperty("ad")]
        public object Ad
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
        public object ReviewScore
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
        public object[] programList
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

        [JsonProperty("contentPage")]
        public object ContentPage
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
        public object[] Comments
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