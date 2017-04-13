using Newtonsoft.Json;

namespace U148.Models
{
    [JsonObject]
    public class ResultBase
    {
        [JsonProperty("code")]
        public int ErrorCode
        {
            get;
            set;
        }

        [JsonProperty("msg")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}