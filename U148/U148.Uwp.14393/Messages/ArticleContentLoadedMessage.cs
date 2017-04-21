using System;
using GalaSoft.MvvmLight.Messaging;
using U148.Models;

namespace U148.Uwp.Messages
{
    public class ArticleContentLoadedMessage : MessageBase
    {
        public ArticleContentLoadedMessage(Article article, string content)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Article = article;
            Content = content;
        }

        public Article Article
        {
            get;
        }

        public string Content
        {
            get;
        }
    }
}