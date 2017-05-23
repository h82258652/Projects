using System.Threading.Tasks;

namespace SoftwareKobo.Controls
{
    public partial interface IImageLoader
    {
        Task<BitmapResult> GetBitmapAsync(string source);
    }
}