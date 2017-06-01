using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class GameType
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("isSelected")]
        public bool IsSelected
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
    }
}