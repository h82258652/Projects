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
        public async Task<bool> SaveFileAsync(byte[] bytes, string suggestedFileName)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
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