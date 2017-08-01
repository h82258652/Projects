using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Sign
    {
        [JsonProperty("continuityCount")]
        public int ContinuityCount
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

        [JsonProperty("lastModifyTime")]
        public string LastModifyTime
        {
            get;
            set;
        }

        [JsonProperty("signCount")]
        public int SignCount
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

        [JsonProperty("userID")]
        public int UserID
        {
            get;
            set;
        }
    }
}