using GalaSoft.MvvmLight.Messaging;

namespace VGtime.Uwp.Messages
{
    public class PostContentLoadedMessage : MessageBase
    {
        public PostContentLoadedMessage(string content)
        {
            Content = content;
        }

        public string Content
        {
            get;
        }
    }
}