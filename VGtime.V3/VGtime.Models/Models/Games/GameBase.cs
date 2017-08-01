using Newtonsoft.Json;
using VGtime.Models.Timeline;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class GameBase
    {
        [JsonProperty("action")]
        public TimeLineAction Action
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

        [JsonProperty("gameId")]
        public int GameId
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

        [JsonProperty("imageCount")]
        public int ImageCount
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

        [JsonProperty("isOnSale")]
        public bool IsOnSale
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

        [JsonProperty("platformsId")]
        public string PlatformsId
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

        [JsonProperty("publishDate")]
        public string PublishDate
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

        [JsonProperty("review")]
        public TimeLineBase Review
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

        [JsonProperty("scoreCount")]
        public int ScoreCount
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

        [JsonProperty("shortPostCount")]
        public int ShortPostCount
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
        public TimeLineImage Thumbnail
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

        [JsonProperty("typesId")]
        public string TypesId
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
    }
}