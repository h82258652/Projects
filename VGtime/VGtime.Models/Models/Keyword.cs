using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class Keyword
    {
        [JsonProperty("keyword")]
        public string Data
        {
            get;
            set;
        }
    }
}