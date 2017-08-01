using Newtonsoft.Json;

namespace VGtime.Models.Users
{
    [JsonObject]
    public class PsnInfo
    {
        [JsonProperty("avatar")]
        public string Avatar
        {
            get;
            set;
        }

        [JsonProperty("completionperc")]
        public string Completionperc
        {
            get;
            set;
        }

        [JsonProperty("copper")]
        public string Copper
        {
            get;
            set;
        }

        [JsonProperty("gameCompleted")]
        public string GameCompleted
        {
            get;
            set;
        }

        [JsonProperty("gamePlayed")]
        public string GamePlayed
        {
            get;
            set;
        }

        [JsonProperty("gold")]
        public string Gold
        {
            get;
            set;
        }

        [JsonProperty("hkRank")]
        public string HkRank
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

        [JsonProperty("isFinish")]
        public int IsFinish
        {
            get;
            set;
        }

        [JsonProperty("ispay")]
        public int Ispay
        {
            get;
            set;
        }

        [JsonProperty("medalLevel")]
        public string MedalLevel
        {
            get;
            set;
        }

        [JsonProperty("medalRate")]
        public string MedalRate
        {
            get;
            set;
        }

        [JsonProperty("nickName")]
        public string NickName
        {
            get;
            set;
        }

        [JsonProperty("points")]
        public string Points
        {
            get;
            set;
        }

        [JsonProperty("possibleTrophies")]
        public string PossibleTrophies
        {
            get;
            set;
        }

        [JsonProperty("psnId")]
        public string PsnId
        {
            get;
            set;
        }

        [JsonProperty("psnUrl")]
        public string PsnUrl
        {
            get;
            set;
        }

        [JsonProperty("rankUrl")]
        public string RankUrl
        {
            get;
            set;
        }

        [JsonProperty("silver")]
        public string Silver
        {
            get;
            set;
        }

        [JsonProperty("trophiesEarned")]
        public string TrophiesEarned
        {
            get;
            set;
        }

        [JsonProperty("vgavatar")]
        public string Vgavatar
        {
            get;
            set;
        }

        [JsonProperty("white")]
        public string White
        {
            get;
            set;
        }

        [JsonProperty("worldRank")]
        public string WorldRank
        {
            get;
            set;
        }
    }
}