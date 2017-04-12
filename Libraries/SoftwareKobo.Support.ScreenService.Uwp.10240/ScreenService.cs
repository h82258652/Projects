using SoftwareKobo.PInvoke;

namespace SoftwareKobo.Support
{
    public class ScreenService : IScreenService
    {
        public uint ScreenHeightInRawPixels => (uint)User32.GetSystemMetrics(SystemMetric.CYSCREEN);

        public uint ScreenWidthInRawPixels => (uint)User32.GetSystemMetrics(SystemMetric.CXSCREEN);
    }
}