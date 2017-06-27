using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftwareKobo.Extensions
{
    public static class FileExtensions
    {
        public static async Task DeleteAsync(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            await Task.Run(() =>
            {
                File.Delete(path);
            });
        }

        public static Task<byte[]> ReadAllBytesAsync(string path)
        {
            return ReadAllBytesAsync(path, CancellationToken.None);
        }

        public static async Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            using (var fs = File.OpenRead(path))
            {
                var buffer = new byte[fs.Length];
                await fs.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                return buffer;
            }
        }

        public static Task<string[]> ReadAllLinesAsync(string path)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8);
        }

        public static async Task<string[]> ReadAllLinesAsync(string path, Encoding encoding)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            var lines = new List<string>();
            using (var fs = File.Open(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, encoding))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines.ToArray();
        }

        public static Task<string> ReadAllTextAsync(string path)
        {
            return ReadAllTextAsync(path, Encoding.UTF8);
        }

        public static async Task<string> ReadAllTextAsync(string path, Encoding encoding)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            using (var fs = File.Open(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs, encoding))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }

        public static Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            return WriteAllBytesAsync(path, bytes, CancellationToken.None);
        }

        public static async Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            using (var fs = File.Create(path))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
            }
        }

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents)
        {
            return WriteAllLinesAsync(path, contents, Encoding.UTF8);
        }

        public static async Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (contents == null)
            {
                throw new ArgumentNullException(nameof(contents));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            using (var fs = File.Create(path))
            {
                using (var sw = new StreamWriter(fs, encoding))
                {
                    foreach (var line in contents)
                    {
                        await sw.WriteLineAsync(line);
                    }
                }
            }
        }

        public static Task WriteAllTextAsync(string path, string contents)
        {
            return WriteAllTextAsync(path, contents, Encoding.UTF8);
        }

        public static async Task WriteAllTextAsync(string path, string contents, Encoding encoding)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            if (contents == null)
            {
                throw new ArgumentNullException(nameof(contents));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            using (var fs = File.Create(path))
            {
                using (var sw = new StreamWriter(fs, encoding))
                {
                    await sw.WriteAsync(contents);
                }
            }
        }
    }
}