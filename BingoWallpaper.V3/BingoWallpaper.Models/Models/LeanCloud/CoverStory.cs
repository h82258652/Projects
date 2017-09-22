﻿using Newtonsoft.Json;

namespace BingoWallpaper.Models.LeanCloud
{
    [JsonObject]
    public class CoverStory
    {
        [JsonProperty("attribute")]
        public string Attribute
        {
            get;
            set;
        }

        [JsonProperty("City")]
        public string City
        {
            get;
            set;
        }

        [JsonProperty("CityInEnglish")]
        public string CityInEnglish
        {
            get;
            set;
        }

        [JsonProperty("Continent")]
        public string Continent
        {
            get;
            set;
        }

        [JsonProperty("Country")]
        public string Country
        {
            get;
            set;
        }

        [JsonProperty("CountryCode")]
        public string CountryCode
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

        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get;
            set;
        }

        [JsonProperty("Latitude")]
        public string Latitude
        {
            get;
            set;
        }

        [JsonProperty("Longitude")]
        public string Longitude
        {
            get;
            set;
        }

        [JsonProperty("para1")]
        public string Parameter1
        {
            get;
            set;
        }

        [JsonProperty("para2")]
        public string Parameter2
        {
            get;
            set;
        }

        [JsonProperty("primaryImageUrl")]
        public string PrimaryImageUrl
        {
            get;
            set;
        }

        [JsonProperty("provider")]
        public string Provider
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }
    }
}