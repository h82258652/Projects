using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class PsnGameMedalListItem
    {
        [JsonProperty("key")]
        public string Key
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public PsnGameMedalListItemValueItem[] Value
        {
            get;
            set;
        }
    }
}