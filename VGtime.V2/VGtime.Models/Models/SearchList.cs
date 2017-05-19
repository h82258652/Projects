using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class SearchList<T>
    {
        [JsonProperty("searchList")]
        public T[] Data
        {
            get;
            set;
        }
    }
}