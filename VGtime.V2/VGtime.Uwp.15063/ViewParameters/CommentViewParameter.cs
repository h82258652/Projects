namespace VGtime.Uwp.ViewParameters
{
    public class CommentViewParameter
    {
        public CommentViewParameter(int postId, int detailType)
        {
            PostId = postId;
            DetailType = detailType;
        }

        public int PostId
        {
            get;
        }

        public int DetailType
        {
            get;
        }
    }
}