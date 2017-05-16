namespace VGtime.Uwp.ViewParameters
{
    public class RelationListViewParameter
    {
        public RelationListViewParameter(int gameId, int type)
        {
            GameId = gameId;
            Type = type;
        }

        public int GameId
        {
            get;
        }

        public int Type
        {
            get;
        }
    }
}