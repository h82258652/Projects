using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class PostStatusHost
    {
        [JsonProperty("postStatus")]
        public PostStatus Data
        {
            get;
            set;
        }
    }
}