using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Models.Article;

namespace VGtime.Uwp.Messages
{
    public class ArticleDetailLoadedMessage : MessageBase
    {
        public ArticleDetailLoadedMessage(ArticleDetail articleDetail, int page)
        {
            if (articleDetail == null)
            {
                throw new ArgumentNullException(nameof(articleDetail));
            }

            ArticleDetail = articleDetail;
            Page = page;
        }

        public ArticleDetail ArticleDetail
        {
            get;
        }

        public int Page
        {
            get;
        }
    }
}