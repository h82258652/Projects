using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class GameBase
    {
        [JsonProperty("gameId")]
        public int GameId
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

        [JsonProperty("platformsText")]
        public string PlatformsText
        {
            get;
            set;
        }

        [JsonProperty("platformsId")]
        public string PlatformsId
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public float Score
        {
            get;
            set;
        }

        [JsonProperty("introduction")]
        public string Introduction
        {
            get;
            set;
        }

        [JsonProperty("publishDate")]
        public string PublishDate
        {
            get;
            set;
        }

        [JsonProperty("typesText")]
        public string TypesText
        {
            get;
            set;
        }

        [JsonProperty("typesId", NullValueHandling = NullValueHandling.Ignore)]
        public int TypesId
        {
            get;
            set;
        }

        [JsonProperty("imageCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ImageCount
        {
            get;
            set;
        }

        [JsonProperty("shortPostCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ShortPostCount
        {
            get;
            set;
        }

        [JsonProperty("longPostCount", NullValueHandling = NullValueHandling.Ignore)]
        public int LongPostCount
        {
            get;
            set;
        }

        [JsonProperty("scoreCount", NullValueHandling = NullValueHandling.Ignore)]
        public int ScoreCount
        {
            get;
            set;
        }

        [JsonProperty("questionCount", NullValueHandling = NullValueHandling.Ignore)]
        public int QuestionCount
        {
            get;
            set;
        }

        [JsonProperty("strategyCount", NullValueHandling = NullValueHandling.Ignore)]
        public int StrategyCount
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

        [JsonProperty("distributor")]
        public string Distributor
        {
            get;
            set;
        }

        [JsonProperty("action")]
        public Action Action
        {
            get;
            set;
        }

        [JsonProperty("isOnSale")]
        public bool IsOnSale
        {
            get;
            set;
        }

        [JsonProperty("review")]
        public Post Review
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

        [JsonProperty("myScore")]
        public object MyScore
        {
            get;
            set;
        }

        [JsonProperty("myContent")]
        public object MyContent
        {
            get;
            set;
        }

        [JsonProperty("hasPsnGame")]
        public bool HasPsnGame
        {
            get;
            set;
        }
    }
}