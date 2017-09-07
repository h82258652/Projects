using System;
using System.Collections.Generic;
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
            fileSavePicker.FileTypeChoices.Add(".jpg", new List<string>()
            {
                ".jpg"
            });
            fileSavePicker.SuggestedFileName = suggestedFileName;
            fileSavePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            var file = await fileSavePicker.PickSaveFileAsync();

            if (file != null)
            {
                await FileIO.WriteBytesAsync(file, bytes);
            }

            throw new NotImplementedException();
        }
    }
}