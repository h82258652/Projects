using Newtonsoft.Json;

namespace VGtime.Models.Wx
{
    [JsonObject]
    public class Wx
    {
        [JsonProperty("access_token")]
        public string AccessToken
        {
            get;
            set;
        }

        [JsonProperty("city")]
        public string City
        {
            get;
            set;
        }

        [JsonProperty("country")]
        public string Country
        {
            get;
            set;
        }

        [JsonProperty("expires_in")]
        public int ExpiresIn
        {
            get;
            set;
        }

        [JsonProperty("headimgurl")]
        public string Headimgurl
        {
            get;
            set;
        }

        [JsonProperty("nickname")]
        public string Nickname
        {
            get;
            set;
        }

        [JsonProperty("openid")]
        public string Openid
        {
            get;
            set;
        }

        [JsonProperty("province")]
        public string Province
        {
            get;
            set;
        }

        [JsonProperty("refresh_token")]
        public string RefreshToken
        {
            get;
            set;
        }

        [JsonProperty("scope")]
        public string Scope
        {
            get;
            set;
        }

        [JsonProperty("sex")]
        public string Sex
        {
            get;
            set;
        }

        [JsonProperty("unionid")]
        public string Unionid
        {
            get;
            set;
        }
    }
}