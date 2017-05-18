using System;
using VGtime.Models;

namespace VGtime.Uwp.Messages
{
    public class PostDetailLoadedMessage : GalaSoft.MvvmLight.Messaging.MessageBase
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