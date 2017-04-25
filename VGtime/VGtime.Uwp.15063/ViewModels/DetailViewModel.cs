using System.Net;
using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Messages;

namespace VGtime.Uwp.ViewModels
{
    public class DetailViewModel : ViewModelBase, INavigable
    {
        private readonly IPostService _postService;

        public DetailViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public async void Activate(object parameter)
        {
            Post post = (Post)parameter;

            var result = await _postService.GetDetailAsync(post.PostId, 0);
            if (result.ErrorCode == HttpStatusCode.OK)
            {
                var dataData = result.Data.Data;
                var dataDataContent = dataData.Content;

                MessengerInstance.Send(new PostContentLoadedMessage(dataDataContent));
            }
        }

        public void Deactivate(object parameter)
        {
        }
    }
}