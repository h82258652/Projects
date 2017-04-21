using Windows.System.Profile;

namespace SoftwareKobo.Helpers
{
    public static class DeviceFamilyHelper
    {
        public static bool IsDesktop => AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop";

        public static bool IsMobile => AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";
    }
}