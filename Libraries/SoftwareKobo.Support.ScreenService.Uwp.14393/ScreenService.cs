using Windows.Graphics.Display;

namespace SoftwareKobo.Support
{
    public class ScreenService : IScreenService
    {
        public uint ScreenHeightInRawPixels => DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels;

        public uint ScreenWidthInRawPixels => DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels;
    }
}