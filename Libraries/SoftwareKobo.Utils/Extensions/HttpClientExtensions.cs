using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftwareKobo.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<byte[]> GetByteArrayAsync(this HttpClient client, Uri requestUri, IProgress<HttpProgress> progress)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            if (requestUri == null)
            {
                throw new ArgumentNullException(nameof(requestUri));
            }

            var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsByteArrayAsync(progress);
        }

        public static Task<byte[]> GetByteArrayAsync(this HttpClient client, string requestUri, IProgress<HttpProgress> progress)
        {
            return client.GetByteArrayAsync(CreateUri(requestUri), progress);
        }

        private static Uri CreateUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return null;
            }
            return new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}