using Newtonsoft.Json;

namespace VGtime.Models.Topic
{
    [JsonObject]
    public class TopicDetailProgram
    {
        [JsonProperty("data")]
        public TopicDetailProgramItem[] Data
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

        [JsonProperty("name")]
        public string Name
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
    }
}