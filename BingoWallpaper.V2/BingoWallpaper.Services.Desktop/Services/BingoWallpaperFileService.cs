using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoWallpaper.Services
{
    public class BingoWallpaperFileService : IBingoWallpaperFileService
    {
        public Task SaveFileAsync(string suggestedFileName, byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = suggestedFileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //FileExtensions.
                }
            }

            throw new NotImplementedException();
        }
    }
}