namespace VGtime.Uwp.ViewParameters
{
    public class ArticleDetailViewParameter
    {
        public ArticleDetailViewParameter(int postId, int detailType)
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