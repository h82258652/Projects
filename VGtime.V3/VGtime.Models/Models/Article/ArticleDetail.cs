using Newtonsoft.Json;

namespace VGtime.Models.Article
{
    [JsonObject]
    public class ArticleDetail
    {
        [JsonProperty("ablumList")]
        public ArticleDetailAblum[] AblumList
        {
            get;
            set;
        }

        [JsonProperty("action")]
        public TimeLineAction Action
        {
            get;
            set;
        }

        [JsonProperty("ad")]
        public Advertising Ad
        {
            get;
            set;
        }

        [JsonProperty("advantageList")]
        public string AdvantageList
        {
            get;
            set;
        }

        [JsonProperty("anchor")]
        public ArticleDetailAnchor[] Anchor
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

        [JsonProperty("category")]
        public string Category
        {
            get;
            set;
        }

        [JsonProperty("comment")]
        public ArticleDetail Comment
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

        [JsonProperty("comments")]
        public ArticleDetail[] Comments
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

        [JsonProperty("contentPage")]
        public int ContentPage
        {
            get;
            set;
        }

        [JsonProperty("cover")]
        public string Cover
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

        [JsonProperty("disadvantageList")]
        public string DisadvantageList
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

        [JsonProperty("game")]
        public GameBase Game
        {
            get;
            set;
        }

        [JsonProperty("games")]
        public ArticleRelatedGame[] Games
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

        [JsonProperty("isQuestion")]
        public bool IsQuestion
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

        [JsonProperty("isSolve")]
        public bool IsSolve
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

        [JsonProperty("news")]
        public ArticleDetail[] News
        {
            get;
            set;
        }

        [JsonProperty("originalPost")]
        public ArticleDetail OriginalPost
        {
            get;
            set;
        }

        [JsonProperty("parentSource")]
        public ArticleDetailParentSource ParentSource
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

        [JsonProperty("programList")]
        public ArticleDetailProgram[] ProgramList
        {
            get;
            set;
        }

        [JsonProperty("publishDate")]
        public long PublishDate
        {
            get;
            set;
        }

        [JsonProperty("relatedGame")]
        public ArticleRelatedGame[] RelatedGame
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
        public float ReviewScore
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

        [JsonProperty("videoList")]
        public ArticleDetailVideo[] VideoList
        {
            get;
            set;
        }

        [JsonProperty("voteList")]
        public ArticleDetailVote[] VoteList
        {
            get;
            set;
        }
    }
}