using System;
using U148.Models;

namespace U148.Uwp.Controls
{
    public class CommentItemReplyEventArgs : EventArgs
    {
        public CommentItemReplyEventArgs(Comment comment, string replyContent)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            if (replyContent == null)
            {
                throw new ArgumentNullException(nameof(replyContent));
            }

            Comment = comment;
            ReplyContent = replyContent;
        }

        public string ReplyContent
        {
            get;
        }

        public Comment Comment
        {
            get;
        }
    }
}