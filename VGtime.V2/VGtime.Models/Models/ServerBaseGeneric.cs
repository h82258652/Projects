using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class ServerBase<T> : ServerBase
    {
        [JsonProperty("data")]
        public T Data
        {
            get;
            set;
        }
    }
}