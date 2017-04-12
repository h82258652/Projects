using Windows.System.Profile;

namespace SoftwareKobo.Social.SinaWeibo.Helpers
{
    internal static class DeviceFamilyHelper
    {
        internal static bool IsMobile => AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";
    }
}