using Newtonsoft.Json;

namespace VGtime.Models.Topic
{
    [JsonObject]
    public class TopicDetail
    {
        [JsonProperty("data")]
        public TopicItem[] Data
        {
            get;
            set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }

        [JsonProperty("retcode")]
        public int Retcode
        {
            get;
            set;
        }

        [JsonProperty("subject")]
        public TopicDetailSubject Subject
        {
            get;
            set;
        }
    }
}