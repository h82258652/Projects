using System;
using System.IO;
using System.Threading.Tasks;
using SoftwareKobo.Properties;

namespace SoftwareKobo.Extensions
{
    public static class DirectoryExtensions
    {
        public static async Task CopyAsync(string sourceDirName, string destDirName)
        {
            if (sourceDirName == null)
            {
                throw new ArgumentNullException(nameof(sourceDirName));
            }
            if (destDirName == null)
            {
                throw new ArgumentNullException(nameof(destDirName));
            }
            if (sourceDirName.Length <= 0)
            {
                throw new ArgumentException(Resources.EmptyStringExceptionMessage, nameof(sourceDirName));
            }
            if (destDirName.Length <= 0)
            {
                throw new ArgumentException(Resources.EmptyStringExceptionMessage, nameof(destDirName));
            }

            Directory.CreateDirectory(destDirName);
            foreach (var sourceFilePath in Directory.GetFiles(sourceDirName))
            {
                var fileName = Path.GetFileName(sourceFilePath);
                var destFilePath = Path.Combine(destDirName, fileName);
                await FileExtensions.CopyAsync(sourceFilePath, destFilePath, true);
            }
            foreach (var sourceChildDirPath in Directory.GetDirectories(sourceDirName))
            {
                var sourceChildDirName = Path.GetFileName(sourceChildDirPath);
                var destChildDirPath = Path.Combine(destDirName, sourceChildDirName);
                await CopyAsync(sourceChildDirPath, destChildDirPath);
            }
        }
    }
}