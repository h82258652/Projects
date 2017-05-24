using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Models.Article;

namespace VGtime.Uwp.Messages
{
    public class ArticleDetailLoadedMessage : MessageBase
    {
        public ArticleDetailLoadedMessage(ArticleDetail articleDetail)
        {
            if (articleDetail == null)
            {
                throw new ArgumentNullException(nameof(articleDetail));
            }

            ArticleDetail = articleDetail;
        }

        public ArticleDetail ArticleDetail
        {
            get;
        }
    }
}