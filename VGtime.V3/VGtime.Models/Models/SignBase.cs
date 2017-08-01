using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class SignBase
    {
        [JsonProperty("data")]
        public Sign Data
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

        [JsonProperty("today")]
        public string Today
        {
            get;
            set;
        }
    }
}