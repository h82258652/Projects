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

        [JsonProperty("typesId")]
        public object typesId
        {
            get;
            set;
        }

        [JsonProperty("imageCount")]
        public object imageCount
        {
            get;
            set;
        }

        [JsonProperty("shortPostCount")]
        public object shortPostCount
        {
            get;
            set;
        }

        [JsonProperty("longPostCount")]
        public object longPostCount
        {
            get;
            set;
        }

        [JsonProperty("scoreCount")]
        public object scoreCount
        {
            get;
            set;
        }

        [JsonProperty("questionCount")]
        public object questionCount
        {
            get;
            set;
        }

        public object strategyCount
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

        public object distributor
        {
            get;
            set;
        }

        [JsonProperty("action")]
        public object action
        {
            get;
            set;
        }

        [JsonProperty("isOnSale")]
        public bool isOnSale
        {
            get;
            set;
        }

        [JsonProperty("review")]
        public object review
        {
            get;
            set;
        }

        [JsonProperty("shareUrl")]
        public object shareUrl
        {
            get;
            set;
        }

        [JsonProperty("myScore")]
        public object myScore
        {
            get;
            set;
        }

        [JsonProperty("myContent")]
        public object myContent
        {
            get;
            set;
        }
    }
}