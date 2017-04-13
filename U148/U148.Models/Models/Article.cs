using System;
using Newtonsoft.Json;
using U148.Models.JsonConverters;

namespace U148.Models
{
    [JsonObject]
    public class Article
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("uid")]
        public int Uid
        {
            get;
            set;
        }

        [JsonProperty("category")]
        public ArticleCategory Category
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

        [JsonProperty("summary")]
        public string Summary
        {
            get;
            set;
        }

        [JsonProperty("tids")]
        public string Tids
        {
            get;
            set;
        }

        [JsonProperty("tags")]
        public string Tags
        {
            get;
            set;
        }

        [JsonProperty("pic_min")]
        public string PicMin
        {
            get;
            set;
        }

        [JsonProperty("pic_mid")]
        public string PicMid
        {
            get;
            set;
        }

        [JsonProperty("is_index")]
        public int IsIndex
        {
            get;
            set;
        }

        [JsonProperty("is_hot")]
        public int IsHot
        {
            get;
            set;
        }

        [JsonProperty("is_top")]
        public int IsTop
        {
            get;
            set;
        }

        [JsonProperty("star")]
        public int Star
        {
            get;
            set;
        }

        [JsonProperty("count_browse")]
        public int CountBrowse
        {
            get;
            set;
        }

        [JsonProperty("count_review")]
        public int CountReview
        {
            get;
            set;
        }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreateTime
        {
            get;
            set;
        }

        [JsonProperty("update_time")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset UpdateTime
        {
            get;
            set;
        }

        [JsonProperty("start_time")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset StartTime
        {
            get;
            set;
        }

        [JsonProperty("usr")]
        public ArticleUser User
        {
            get;
            set;
        }
    }
}