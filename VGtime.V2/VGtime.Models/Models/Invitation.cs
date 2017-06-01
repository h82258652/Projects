using Newtonsoft.Json;
using VGtime.Models.Users;

namespace VGtime.Models
{
    [JsonObject]
    public class Invitation
    {
        [JsonProperty("user")]
        public UserBase User
        {
            get;
            set;
        }
    }
}