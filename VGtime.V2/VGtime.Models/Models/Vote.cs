using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Vote
    {
        [JsonProperty("day")]
        public int Day
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

        [JsonProperty("isMult")]
        public bool IsMult
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

        [JsonProperty("isexpired")]
        public bool Isexpired
        {
            get;
            set;
        }

        [JsonProperty("itemList")]
        public VoteItem[] ItemList
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

        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }
    }
}