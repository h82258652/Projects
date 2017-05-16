namespace VGtime.Uwp.ViewParameters
{
    public class DetailViewParameter
    {
        public DetailViewParameter(int postId, int detailType)
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