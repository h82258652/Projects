using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PushList<T>
    {
        [JsonProperty("pushList")]
        public T[] Data
        {
            get;
            set;
        }
    }
}