using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Models.Timeline;

namespace VGtime.Uwp.Messages
{
    public class ArticleDetailLoadedMessage : MessageBase
    {
        public ArticleDetailLoadedMessage(TimeLineBase articleDetail)
        {
            if (articleDetail == null)
            {
                throw new ArgumentNullException(nameof(articleDetail));
            }

            ArticleDetail = articleDetail;
        }

        public TimeLineBase ArticleDetail
        {
            get;
        }
    }
}