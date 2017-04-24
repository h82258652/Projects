using Newtonsoft.Json;

namespace VGtime.Models
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