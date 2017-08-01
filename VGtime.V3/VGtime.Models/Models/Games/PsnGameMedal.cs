using Newtonsoft.Json;

namespace VGtime.Models.Games
{
    [JsonObject]
    public class PsnGameMedal
    {
        [JsonProperty("dlcMedalList")]
        public PsnGameMedalListItem[] DlcMedalList
        {
            get;
            set;
        }

        [JsonProperty("firstTime")]
        public string FirstTime
        {
            get;
            set;
        }

        [JsonProperty("haspsnId")]
        public int HaspsnId
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

        [JsonProperty("lastTime")]
        public string LastTime
        {
            get;
            set;
        }

        [JsonProperty("medalcount")]
        public int Medalcount
        {
            get;
            set;
        }

        [JsonProperty("mymedalcount")]
        public int Mymedalcount
        {
            get;
            set;
        }
    }
}