using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoWallpaper.Services
{
    public class BingoWallpaperFileService : IBingoWallpaperFileService
    {
        public async Task<bool> SaveFileAsync(string suggestedFileName, byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            var extension = Path.GetExtension(suggestedFileName);
            using (var saveFileDialog = new SaveFileDialog()
            {
                Filter = $"*{extension}|*{extension}",
                FileName = suggestedFileName
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO
                    File.WriteAllBytes(saveFileDialog.FileName, bytes);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}