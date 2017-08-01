using Newtonsoft.Json;

namespace VGtime.Models.Topic
{
    [JsonObject]
    public class TopicItem
    {
        [JsonProperty("author")]
        public string Author
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

        [JsonProperty("duration")]
        public string Duration
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

        [JsonProperty("isVideo")]
        public bool IsVideo
        {
            get;
            set;
        }

        [JsonProperty("preDate")]
        public string PreDate
        {
            get;
            set;
        }

        [JsonProperty("preTime")]
        public string PreTime
        {
            get;
            set;
        }

        [JsonProperty("programId")]
        public int ProgramId
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
        public int Sort
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
    }
}