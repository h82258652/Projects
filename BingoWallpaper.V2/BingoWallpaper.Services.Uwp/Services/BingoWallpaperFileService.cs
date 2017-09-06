using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace BingoWallpaper.Services
{
    public class BingoWallpaperFileService : IBingoWallpaperFileService
    {
        public async Task SaveFileAsync(string suggestedFileName, byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            var fileSavePicker = new FileSavePicker();

            var file = await fileSavePicker.PickSaveFileAsync();

            if (file != null)
            {
                await FileIO.WriteBytesAsync(file, bytes);
            }

            throw new NotImplementedException();
        }
    }
}