using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Models;

namespace VGtime.Uwp.Messages
{
    public class PostDetailLoadedMessage : MessageBase
    {
        public PostDetailLoadedMessage(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            Post = post;
        }

        public Post Post
        {
            get;
        }
    }
}