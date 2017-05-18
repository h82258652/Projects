using System;
using Newtonsoft.Json;
using VGtime.Models.JsonConverters;

namespace VGtime.Models
{
    [JsonObject]
    public class Advertising
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("channelId")]
        public int ChannelId
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

        [JsonProperty("webPic")]
        public string WebPic
        {
            get;
            set;
        }

        [JsonProperty("appPic")]
        public string AppPic
        {
            get;
            set;
        }

        [JsonProperty("advertiser")]
        public string Advertiser
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

        [JsonProperty("click")]
        public int Click
        {
            get;
            set;
        }

        [JsonProperty("createTime")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTimeOffset CreateTime
        {
            get;
            set;
        }
    }
}