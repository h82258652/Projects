using Newtonsoft.Json;

namespace VGtime.Models.Wx
{
    [JsonObject]
    public class CheckToken
    {
        [JsonProperty("errcode")]
        public int Errcode
        {
            get;
            set;
        }

        [JsonProperty("errmsg")]
        public string Errmsg
        {
            get;
            set;
        }
    }
}