using Newtonsoft.Json;
using VGtime.Models.Users;

namespace VGtime.Models
{
    [JsonObject]
    public class InvitationRank
    {
        [JsonProperty("number")]
        public int Number
        {
            get;
            set;
        }

        [JsonProperty("ranking")]
        public int Ranking
        {
            get;
            set;
        }

        [JsonProperty("user")]
        public UserBase User
        {
            get;
            set;
        }
    }
}