using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Version
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("created_time")]
        public long CreatedTime
        {
            get;
            set;
        }

        [JsonProperty("vers_code")]
        public int VersCode
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

        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        [JsonProperty("comp")]
        public int Comp
        {
            get;
            set;
        }

        [JsonProperty("version_name")]
        public string VersionName
        {
            get;
            set;
        }

        [JsonProperty("vtype")]
        public int VType
        {
            get;
            set;
        }

        [JsonProperty("catagory")]
        public int Catagory
        {
            get;
            set;
        }

        [JsonProperty("start_picture")]
        public string StartPicture
        {
            get;
            set;
        }
    }
}