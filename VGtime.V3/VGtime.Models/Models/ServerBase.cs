using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class ServerBase
    {
        [JsonProperty("currentPage")]
        public int CurrentPage
        {
            get;
            set;
        }

        [JsonProperty("data")]
        public object Data
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

        [JsonProperty("pageSize")]
        public int PageSize
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

        [JsonProperty("totalPage")]
        public int TotalPage
        {
            get;
            set;
        }
    }
}