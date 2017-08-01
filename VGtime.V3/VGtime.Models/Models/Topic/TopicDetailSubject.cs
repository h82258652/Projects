using Newtonsoft.Json;

namespace VGtime.Models.Topic
{
    [JsonObject]
    public class TopicDetailSubject
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

        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("programNum")]
        public int ProgramNum
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

        [JsonProperty("showLive")]
        public int ShowLive
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

        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public int Type
        {
            get;
            set;
        }
    }
}