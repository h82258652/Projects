using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VGtime.Models
{
    [JsonObject]
    public class KeywordList
    {
        [JsonProperty("keywordList")]
        public Keyword[] Data
        {
            get;
            set;
        }
    }
}