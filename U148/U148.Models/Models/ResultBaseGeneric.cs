using Newtonsoft.Json;

namespace U148.Models
{
    [JsonObject]
    public class ResultBase<T> : ResultBase
    {
        [JsonProperty("data")]
        public T Data
        {
            get;
            set;
        }
    }
}