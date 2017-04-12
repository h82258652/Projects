using System.Windows.Forms;

namespace SoftwareKobo.Support
{
    public class ScreenService : IScreenService
    {
        public uint ScreenHeightInRawPixels => (uint)Screen.PrimaryScreen.Bounds.Height;

        public uint ScreenWidthInRawPixels => (uint)Screen.PrimaryScreen.Bounds.Width;
    }
}