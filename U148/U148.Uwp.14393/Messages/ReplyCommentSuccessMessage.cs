using GalaSoft.MvvmLight.Messaging;
using U148.Models;

namespace U148.Uwp.Messages
{
    public class ReplyCommentSuccessMessage : MessageBase
    {
        public ReplyCommentSuccessMessage(Comment comment)
        {
            Comment = comment;
        }

        /// <summary>
        /// 被回复的评论。
        /// </summary>
        public Comment Comment
        {
            get;
            set;
        }
    }
}