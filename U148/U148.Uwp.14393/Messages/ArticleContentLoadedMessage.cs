using System;
using GalaSoft.MvvmLight.Messaging;

namespace U148.Uwp.Messages
{
    public class ArticleContentLoadedMessage : MessageBase
    {
        public ArticleContentLoadedMessage(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Content = content;
        }

        public string Content
        {
            get;
        }
    }
}