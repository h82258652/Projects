using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace BingoWallpaper.Services
{
    public class BingoWallpaperFileService : IBingoWallpaperFileService
    {
        public async Task<bool> SaveFileAsync(string suggestedFileName, byte[] bytes)
        {
            if (suggestedFileName == null)
            {
                throw new ArgumentNullException(nameof(suggestedFileName));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            var fileSavePicker = new FileSavePicker();
            var extension = Path.GetExtension(suggestedFileName);
            fileSavePicker.FileTypeChoices.Add(extension, new[]
            {
                extension
            });
            fileSavePicker.SuggestedFileName = suggestedFileName;
            fileSavePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            var file = await fileSavePicker.PickSaveFileAsync();

            if (file != null)
            {
                await FileIO.WriteBytesAsync(file, bytes);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}