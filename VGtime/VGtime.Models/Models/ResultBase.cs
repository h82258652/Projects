using System.Net;
using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class ResultBase
    {
        [JsonProperty("message")]
        public string ErrorMessage
        {
            get;
            set;
        }

        [JsonProperty("retcode")]
        public HttpStatusCode ErrorCode
        {
            get;
            set;
        }
    }
}