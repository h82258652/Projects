using System;
using Newtonsoft.Json;
using U148.Models.JsonConverters;

namespace U148.Models
{
    [JsonObject]
    public class FavoriteArticle
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

        [JsonProperty("aid")]
        public int Aid
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

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }

        [JsonProperty("is_stock")]
        public int IsStock
        {
            get;
            set;
        }

        [JsonProperty("is_private")]
        public int IsPrivate
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

        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }

        [JsonProperty("favourite_category")]
        public object FavoriteCategory
        {
            get;
            set;
        }
    }
}