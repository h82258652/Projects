namespace SoftwareKobo.Support
{
    public interface IScreenService
    {
        uint ScreenHeightInRawPixels
        {
            get;
        }

        uint ScreenWidthInRawPixels
        {
            get;
        }
    }
}