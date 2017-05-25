using System.Threading.Tasks;

namespace VGtime.Services
{
    public interface IVGtimeFileService
    {
        Task<bool> SaveFileAsync(byte[] bytes, string suggestedFileName);
    }
}