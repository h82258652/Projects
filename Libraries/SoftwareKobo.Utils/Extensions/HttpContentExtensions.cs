using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftwareKobo.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<byte[]> ReadAsByteArrayAsync(this HttpContent content, IProgress<HttpProgress> progress)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var contentLength = content.Headers.ContentLength;
            var totalBytesToReceive = (ulong?)contentLength;
            progress?.Report(new HttpProgress()
            {
                BytesReceived = 0,
                TotalBytesToReceive = totalBytesToReceive
            });

            var stream = await content.ReadAsStreamAsync();

            var bytes = new List<byte>();

            const int bufferLength = 1024 * 1024;
            var buffer = new byte[bufferLength];
            while (true)
            {
                var readCount = await stream.ReadAsync(buffer, 0, bufferLength);
                if (readCount > 0)
                {
                    bytes.AddRange(buffer.Take(readCount));
                    progress?.Report(new HttpProgress()
                    {
                        BytesReceived = (ulong)bytes.Count,
                        TotalBytesToReceive = totalBytesToReceive
                    });
                }
                else
                {
                    break;
                }
            }

            return bytes.ToArray();
        }
    }
}