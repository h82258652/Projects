using Newtonsoft.Json;
using VGtime.Models.Games;

namespace VGtime.Models
{
    [JsonObject]
    public class AlbumList
    {
        [JsonProperty("ablumList")]
        public GameAlbum[] Data
        {
            get;
            set;
        }
    }
}