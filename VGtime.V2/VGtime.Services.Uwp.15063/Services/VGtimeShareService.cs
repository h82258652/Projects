using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage.Streams;
using SoftwareKobo.Social.SinaWeibo;
using SoftwareKobo.Social.SinaWeibo.Models;

namespace VGtime.Services
{
    public class VGtimeShareService : IVGtimeShareService
    {
        public async Task<ModelBase> ShareToSinaWeiboAsync(string text, byte[] image)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            var client = new SinaWeiboClient(Constants.SinaWeiboAppKey, Constants.SinaWeiboAppSecret, Constants.SinaWeiboRedirectUri);
            return await client.ShareAsync(text, image);
        }

        public async Task ShareToSystemAsync(string title, string text, string imageUrl)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (imageUrl == null)
            {
                throw new ArgumentNullException(nameof(imageUrl));
            }

            if (DataTransferManager.IsSupported())
            {
                var tcs = new TaskCompletionSource<object>();
                var dataTransferManager = DataTransferManager.GetForCurrentView();
                TypedEventHandler<DataTransferManager, DataRequestedEventArgs> handler = null;
                handler = (sender, args) =>
                {
                    dataTransferManager.DataRequested -= handler;
                    var request = args.Request;
                    var deferral = request.GetDeferral();
                    try
                    {
                        var data = request.Data;
                        data.Properties.Title = title;
                        data.SetText(text);
                        data.SetBitmap(RandomAccessStreamReference.CreateFromUri(new Uri(imageUrl, UriKind.Absolute)));
                    }
                    finally
                    {
                        deferral.Complete();
                        tcs.SetResult(null);
                    }
                };
                dataTransferManager.DataRequested += handler;
                DataTransferManager.ShowShareUI();
                await tcs.Task;
            }
        }
    }
}