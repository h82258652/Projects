using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class AlbumList<T>
    {
        [JsonProperty("ablumList")]
        public T[] Data
        {
            get;
            set;
        }
    }
}