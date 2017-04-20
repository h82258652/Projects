using System;
using U148.Models;

namespace U148.Uwp.Controls
{
    public class CommentItemReplyEventArgs : EventArgs
    {
        public CommentItemReplyEventArgs(Comment comment, string content)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Comment = comment;
            Content = content;
        }

        public string Content
        {
            get;
        }

        public Comment Comment
        {
            get;
        }
    }
}