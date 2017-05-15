namespace VGtime.Uwp.ViewModelParameters
{
    public class RelationListViewModelParameter
    {
        public RelationListViewModelParameter(int gameId, int type)
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