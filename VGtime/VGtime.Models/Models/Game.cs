using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Game
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
        public object PlatformsId
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public double Score
        {
            get;
            set;
        }

        [JsonProperty("introduction")]
        public object Introduction
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
        public object TypesText
        {
            get;
            set;
        }

        [JsonProperty("typesId")]
        public object TypesId
        {
            get;
            set;
        }

        [JsonProperty("imageCount")]
        public object ImageCount
        {
            get;
            set;
        }

        [JsonProperty("shortPostCount")]
        public object ShortPostCount
        {
            get;
            set;
        }

        [JsonProperty("longPostCount")]
        public object LongPostCount
        {
            get;
            set;
        }

        [JsonProperty("scoreCount")]
        public object ScoreCount
        {
            get;
            set;
        }

        [JsonProperty("questionCount")]
        public object QuestionCount
        {
            get;
            set;
        }

        [JsonProperty("strategyCount")]
        public object StrategyCount
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
        public object Distributor
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

        [JsonProperty("isOnSale")]
        public bool IsOnSale
        {
            get;
            set;
        }

        [JsonProperty("review")]
        public object Review
        {
            get;
            set;
        }

        [JsonProperty("shareUrl")]
        public object ShareUrl
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
    }
}