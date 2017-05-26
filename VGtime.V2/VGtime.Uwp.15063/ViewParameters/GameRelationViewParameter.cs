namespace VGtime.Uwp.ViewParameters
{
    public class GameRelationViewParameter
    {
        public GameRelationViewParameter(int gameId, int type)
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