using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class PsnGame
    {
        [JsonProperty("copper")]
        public int Copper
        {
            get;
            set;
        }

        [JsonProperty("createTime")]
        public string CreateTime
        {
            get;
            set;
        }

        [JsonProperty("currentUrl")]
        public string CurrentUrl
        {
            get;
            set;
        }

        [JsonProperty("dataCardId")]
        public int DataCardId
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

        [JsonProperty("gameUrl")]
        public string GameUrl
        {
            get;
            set;
        }

        [JsonProperty("gold")]
        public int Gold
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

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("perfectRate")]
        public string PerfectRate
        {
            get;
            set;
        }

        [JsonProperty("picture")]
        public string Picture
        {
            get;
            set;
        }

        [JsonProperty("platform")]
        public string Platform
        {
            get;
            set;
        }

        [JsonProperty("playedNum")]
        public int PlayedNum
        {
            get;
            set;
        }

        [JsonProperty("points")]
        public int Points
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

        [JsonProperty("solver")]
        public int Solver
        {
            get;
            set;
        }

        [JsonProperty("trophies")]
        public int Trophies
        {
            get;
            set;
        }

        [JsonProperty("version")]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty("white")]
        public int White
        {
            get;
            set;
        }
    }
}