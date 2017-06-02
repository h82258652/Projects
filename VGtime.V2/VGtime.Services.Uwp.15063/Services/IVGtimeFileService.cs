using System.Threading.Tasks;
using Windows.Storage;

namespace VGtime.Services
{
    public interface IVGtimeFileService
    {
        Task<IStorageFile> SelectSaveFileAsync(string suggestedFileName);

        Task WriteAllBytesAsync(IStorageFile file, byte[] bytes);
    }
}