using Windows.UI.Composition;

namespace SoftwareKobo.Controls
{
    public partial class ImageEx
    {
        public CompositionBrush GetAlphaMask()
        {
            return _image?.GetAlphaMask();
        }
    }
}