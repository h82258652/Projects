using System.Threading.Tasks;

namespace SoftwareKobo.Controls
{
    public partial interface IImageLoader
    {
        Task<ImageSurfaceResult> GetImageSurfaceAsync(string source);
    }
}