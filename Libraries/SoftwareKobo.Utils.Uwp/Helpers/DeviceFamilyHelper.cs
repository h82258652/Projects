using Windows.System.Profile;

namespace SoftwareKobo.Helpers
{
    public static class DeviceFamilyHelper
    {
        public static bool IsMobile => AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";
    }
}