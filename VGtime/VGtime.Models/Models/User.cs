using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class User
    {
        [JsonProperty("userId")]
        public int UserId
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

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get;
            set;
        }

        [JsonProperty("relation")]
        public int Relation
        {
            get;
            set;
        }

        [JsonProperty("followerCount")]
        public object FollowerCount
        {
            get;
            set;
        }

        [JsonProperty("followCount")]
        public object FollowCount
        {
            get;
            set;
        }

        [JsonProperty("followerDate")]
        public object FollowerDate
        {
            get;
            set;
        }

        [JsonProperty("isHighlight")]
        public object IsHighlight
        {
            get;
            set;
        }
    }
}