namespace VGtime.Uwp.ViewParameters
{
    public class GamePhotoViewParameter
    {
        public GamePhotoViewParameter(int gameId, string gameName)
        {
            GameId = gameId;
            GameName = gameName;
        }

        public int GameId
        {
            get;
        }

        public string GameName
        {
            get;
        }
    }
}