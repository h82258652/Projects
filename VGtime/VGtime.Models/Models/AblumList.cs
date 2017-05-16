using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AblumList<T>
    {
        [JsonProperty("ablumList")]
        public T[] Data
        {
            get;
            set;
        }
    }
}