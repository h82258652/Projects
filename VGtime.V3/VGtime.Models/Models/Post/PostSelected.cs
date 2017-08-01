using Newtonsoft.Json;

namespace VGtime.Models.Post
{
    [JsonObject]
    public class PostSelected
    {
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
    }
}