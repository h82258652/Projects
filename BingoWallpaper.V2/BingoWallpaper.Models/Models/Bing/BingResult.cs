using Newtonsoft.Json;

namespace BingoWallpaper.Models.Bing
{
    [JsonObject]
    public class BingResult
    {
        [JsonProperty("images")]
        public BingImage[] Images
        {
            get;
            set;
        }

        [JsonProperty("tooltips")]
        public Tooltips Tooltips
        {
            get;
            set;
        }
    }
}