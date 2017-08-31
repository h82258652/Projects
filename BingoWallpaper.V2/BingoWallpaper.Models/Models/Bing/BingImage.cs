using Newtonsoft.Json;

namespace BingoWallpaper.Models.Bing
{
    [JsonObject]
    public class BingImage
    {
        [JsonProperty("startdate")]
        public string StartDate
        {
            get;
            set;
        }

        [JsonProperty("fullstartdate")]
        public string FullStartDate
        {
            get;
            set;
        }

        [JsonProperty("enddate")]
        public string EndDate
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

        [JsonProperty("urlbase")]
        public string UrlBase
        {
            get;
            set;
        }

        [JsonProperty("copyright")]
        public string Copyright
        {
            get;
            set;
        }

        [JsonProperty("copyrightlink")]
        public string CopyrightLink
        {
            get;
            set;
        }

        [JsonProperty("quiz")]
        public string Quiz
        {
            get;
            set;
        }

        [JsonProperty("wp")]
        public bool ExistWUXGA
        {
            get;
            set;
        }

        [JsonProperty("hsh")]
        public string Hsh
        {
            get;
            set;
        }

        [JsonProperty("drk")]
        public int Drk
        {
            get;
            set;
        }

        [JsonProperty("top")]
        public int Top
        {
            get;
            set;
        }

        [JsonProperty("bot")]
        public int Bot
        {
            get;
            set;
        }

        [JsonProperty("hs")]
        public object[] Hs
        {
            get;
            set;
        }
    }
}