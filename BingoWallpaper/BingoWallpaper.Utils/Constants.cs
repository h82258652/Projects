using System;

namespace BingoWallpaper
{
    public static class Constants
    {
        public const string BingUrlBase = @"http://global.bing.com";

        public const string ImageUrlBase = "https://wpdn.bohan.co";

        public const string LeanCloudAppId = @"2odv0fmdni1w22hceawylo48l76vxbltgpl1mnoq3hlxj55j";

        public const string LeanCloudAppKey = @"idsoc6l9k218zrge2qi06anel3qcoqgvhutbqm93e4l58d3i";

        public const string LeanCloudUrlBase = @"https://leancloud.cn";

        public const string WebVersionAddress = "https://wp.bohan.co";

        public static readonly DateTimeOffset MinimumViewMonth = new DateTimeOffset(new DateTime(2015, 1, 1));
    }
}