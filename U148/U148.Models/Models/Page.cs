using Newtonsoft.Json;

namespace U148.Models
{
    [JsonObject]
    public class Page<T>
    {
        [JsonProperty("pageNo")]
        public int PageNo
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

        [JsonProperty("pageMax")]
        public int PageMax
        {
            get;
            set;
        }

        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        [JsonProperty("num")]
        public int Num
        {
            get;
            set;
        }

        [JsonProperty("start")]
        public int Start
        {
            get;
            set;
        }

        [JsonProperty("end")]
        public int End
        {
            get;
            set;
        }

        [JsonProperty("pre")]
        public int Pre
        {
            get;
            set;
        }

        [JsonProperty("next")]
        public int Next
        {
            get;
            set;
        }

        [JsonProperty("data")]
        public T[] Data
        {
            get;
            set;
        }
    }
}