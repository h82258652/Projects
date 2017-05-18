using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Advertising
    {
        [JsonProperty("advertiser")]
        public string Advertiser
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

        [JsonProperty("channelId")]
        public int ChannelId
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
        public long CreateTime
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public int Id
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
    }
}