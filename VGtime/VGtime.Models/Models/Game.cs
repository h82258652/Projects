using System;
using System.Collections.Generic;
using System.Text;
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
        public string platformsText
        {
            get;
            set;
        }

        [JsonProperty("platformsId")]
        public object platformsId
        {
            get;
            set;
        }

        [JsonProperty("score")]
        public double score
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

        public object typesId { get; set; }

        public object imageCount { get; set; }

        public object shortPostCount { get; set; }

        public object longPostCount { get; set; }

        public object scoreCount { get; set; }

        public object questionCount { get; set; }

        public object strategyCount { get; set; }

        public Thumbnail thumbnail { get; set; }

        public object distributor { get; set; }

        public object action { get; set; }

        public bool isOnSale { get; set; }

        public object review { get; set; }

        public object shareUrl { get; set; }

        public object myScore { get; set; }

        public object myContent { get; set; }
    }
}