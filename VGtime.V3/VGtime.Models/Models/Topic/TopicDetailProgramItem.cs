using Newtonsoft.Json;

namespace VGtime.Models.Topic
{
    [JsonObject]
    public class TopicDetailProgramItem
    {
        [JsonProperty("appPushId")]
        public string AppPushId
        {
            get;
            set;
        }

        [JsonProperty("author")]
        public string Author
        {
            get;
            set;
        }

        [JsonProperty("autoPubTime")]
        public long AutoPubTime
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

        [JsonProperty("cover")]
        public string Cover
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

        [JsonProperty("gameId")]
        public string GameId
        {
            get;
            set;
        }

        [JsonProperty("gameName")]
        public string GameName
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

        [JsonProperty("notification")]
        public string Notification
        {
            get;
            set;
        }

        [JsonProperty("pubTime")]
        public long PubTime
        {
            get;
            set;
        }

        [JsonProperty("remark")]
        public string Remark
        {
            get;
            set;
        }

        [JsonProperty("sort")]
        public long Sort
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

        [JsonProperty("topicId")]
        public int TopicId
        {
            get;
            set;
        }

        [JsonProperty("typeTagId")]
        public int TypeTagId
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

        [JsonProperty("weight")]
        public string Weight
        {
            get;
            set;
        }
    }
}