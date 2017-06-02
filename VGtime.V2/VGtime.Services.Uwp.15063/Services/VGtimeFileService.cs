using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace VGtime.Services
{
    public class VGtimeFileService : IVGtimeFileService
    {
        public async Task<IStorageFile> SelectSaveFileAsync(string suggestedFileName)
        {
            if (suggestedFileName == null)
            {
                throw new ArgumentNullException(nameof(suggestedFileName));
            }

            var fileExtension = Path.GetExtension(suggestedFileName);
            var fileSavePicker = new FileSavePicker()
            {
                SuggestedFileName = suggestedFileName,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            fileSavePicker.FileTypeChoices.Add(fileExtension, new List<string>()
            {
                fileExtension
            });
            return await fileSavePicker.PickSaveFileAsync();
        }

        public async Task WriteAllBytesAsync(IStorageFile file, byte[] bytes)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            await FileIO.WriteBytesAsync(file, bytes);
        }
    }
}