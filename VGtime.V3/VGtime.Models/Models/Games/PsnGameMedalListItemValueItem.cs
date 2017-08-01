using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class PsnGameMedalListItemValueItem
    {
        [JsonProperty("createTime")]
        public string CreateTime
        {
            get;
            set;
        }

        [JsonProperty("dlcId")]
        public string DlcId
        {
            get;
            set;
        }

        [JsonProperty("gameId")]
        public string GameId
        {
            get;
            set;
        }

        [JsonProperty("getTime")]
        public string GetTime
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("medalId")]
        public int MedalId
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

        [JsonProperty("psnUserId")]
        public string PsnUserId
        {
            get;
            set;
        }

        [JsonProperty("rate")]
        public string Rate
        {
            get;
            set;
        }

        [JsonProperty("remarker")]
        public string Remarker
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public int Type
        {
            get;
            set;
        }

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
    }
}