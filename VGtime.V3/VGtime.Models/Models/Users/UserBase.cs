using Newtonsoft.Json;

namespace VGtime.Models.Users
{
    [JsonObject]
    public class UserBase
    {
        [JsonProperty("androidGold")]
        public int AndroidGold
        {
            get;
            set;
        }

        [JsonProperty("area")]
        public string Area
        {
            get;
            set;
        }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl
        {
            get;
            set;
        }

        [JsonProperty("awardCount")]
        public int AwardCount
        {
            get;
            set;
        }

        [JsonProperty("bandCode")]
        public string BandCode
        {
            get;
            set;
        }

        [JsonProperty("copperAward")]
        public int CopperAward
        {
            get;
            set;
        }

        [JsonProperty("couponCount")]
        public int CouponCount
        {
            get;
            set;
        }

        [JsonProperty("demonValue")]
        public int DemonValue
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        [JsonProperty("followCount")]
        public int FollowCount
        {
            get;
            set;
        }

        [JsonProperty("followerCount")]
        public int FollowerCount
        {
            get;
            set;
        }

        [JsonProperty("followerDate")]
        public string FollowerDate
        {
            get;
            set;
        }

        [JsonProperty("gender")]
        public int Gender
        {
            get;
            set;
        }

        [JsonProperty("goldAward")]
        public int GoldAward
        {
            get;
            set;
        }

        [JsonProperty("heroValue")]
        public int HeroValue
        {
            get;
            set;
        }

        [JsonProperty("inviteCode")]
        public string InviteCode
        {
            get;
            set;
        }

        [JsonProperty("inviteCount")]
        public int InviteCount
        {
            get;
            set;
        }

        [JsonProperty("iosgold")]
        public int Iosgold
        {
            get;
            set;
        }

        [JsonProperty("isHighlight")]
        public bool IsHighlight
        {
            get;
            set;
        }

        [JsonProperty("isPerfect")]
        public bool IsPerfect
        {
            get;
            set;
        }

        [JsonProperty("isSynced")]
        public bool IsSynced
        {
            get;
            set;
        }

        [JsonProperty("isTourist")]
        public bool IsTourist
        {
            get;
            set;
        }

        [JsonProperty("level")]
        public int Level
        {
            get;
            set;
        }

        [JsonProperty("master")]
        public string Master
        {
            get;
            set;
        }

        [JsonProperty("mobile")]
        public string Mobile
        {
            get;
            set;
        }

        [JsonProperty("myCollectNum")]
        public int MyCollectNum
        {
            get;
            set;
        }

        [JsonProperty("myScoreNum")]
        public int MyScoreNum
        {
            get;
            set;
        }

        [JsonProperty("myTimeLineNum")]
        public int MyTimeLineNum
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("password")]
        public string Password
        {
            get;
            set;
        }

        [JsonProperty("psnId")]
        public string PsnId
        {
            get;
            set;
        }

        [JsonProperty("relation")]
        public int Relation
        {
            get;
            set;
        }

        [JsonProperty("silverAward")]
        public int SilverAward
        {
            get;
            set;
        }

        [JsonProperty("sinaId")]
        public string SinaId
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }

        [JsonProperty("tencentId")]
        public string TencentId
        {
            get;
            set;
        }

        [JsonProperty("token")]
        public string Token
        {
            get;
            set;
        }

        [JsonProperty("userId")]
        public int UserId
        {
            get;
            set;
        }

        [JsonProperty("vgExp")]
        public int VgExp
        {
            get;
            set;
        }

        [JsonProperty("vgNextLevelExp")]
        public int VgNextLevelExp
        {
            get;
            set;
        }

        [JsonProperty("vgpoint")]
        public int Vgpoint
        {
            get;
            set;
        }

        [JsonProperty("wechatId")]
        public string WechatId
        {
            get;
            set;
        }
    }
}