using Newtonsoft.Json;

namespace VGtime.Models.Post
{
    [JsonObject]
    public class Upload
    {
        [JsonProperty("index")]
        public int Index
        {
            get;
            set;
        }

        [JsonProperty("picPath")]
        public string PicPath
        {
            get;
            set;
        }

        [JsonProperty("picUrl")]
        public string PicUrl
        {
            get;
            set;
        }

        [JsonProperty("uploadSuccess")]
        public bool UploadSuccess
        {
            get;
            set;
        }
    }
}