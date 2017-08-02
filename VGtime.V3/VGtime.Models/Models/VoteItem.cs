using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class VoteItem
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("isSelect")]
        public bool IsSelect
        {
            get;
            set;
        }

        [JsonProperty("isVote")]
        public bool IsVote
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

        [JsonProperty("rate")]
        public double Rate
        {
            get;
            set;
        }

        [JsonProperty("totalCount")]
        public int TotalCount
        {
            get;
            set;
        }
    }
}