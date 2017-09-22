﻿using Newtonsoft.Json;

namespace BingoWallpaper.Models.LeanCloud
{
    [JsonObject]
    public class Archive : AVObject
    {
        [JsonProperty("cs")]
        public CoverStory CoverStory
        {
            get;
            set;
        }

        [JsonProperty("date")]
        public string Date
        {
            get;
            set;
        }

        [JsonProperty("hs")]
        public Hotspot[] Hotspots
        {
            get;
            set;
        }

        [JsonProperty("image")]
        public LeanCloudPointer Image
        {
            get;

            set;
        }

        [JsonProperty("info")]
        public string Info
        {
            get;
            set;
        }

        [JsonProperty("link")]
        public string Link
        {
            get;
            set;
        }

        [JsonProperty("market")]
        public string Market
        {
            get;
            set;
        }
    }
}