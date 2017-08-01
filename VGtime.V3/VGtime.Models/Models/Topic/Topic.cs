using Newtonsoft.Json;

namespace VGtime.Models.Topic
{
    [JsonObject]
    public class Topic
    {
        [JsonProperty("list")]
        public TopicItem[] List
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

        [JsonProperty("subid")]
        public int Subid
        {
            get;
            set;
        }
    }
}