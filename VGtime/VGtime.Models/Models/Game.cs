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
        public string PlatformsId
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

        [JsonProperty("typesId")]
        public int TypesId
        {
            get;
            set;
        }

        [JsonProperty("imageCount")]
        public int ImageCount
        {
            get;
            set;
        }

        [JsonProperty("shortPostCount")]
        public int ShortPostCount
        {
            get;
            set;
        }

        [JsonProperty("longPostCount")]
        public int LongPostCount
        {
            get;
            set;
        }

        [JsonProperty("scoreCount")]
        public int ScoreCount
        {
            get;
            set;
        }

        [JsonProperty("questionCount")]
        public int QuestionCount
        {
            get;
            set;
        }

        [JsonProperty("strategyCount")]
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
        public object Review
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