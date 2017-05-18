using VGtime.Models;

namespace VGtime.Uwp.ViewParameters
{
    public class AblumDetailViewParameter
    {
        public AblumDetailViewParameter(GameAlbum[] gameAlbums, int index)
        {
            GameAlbums = gameAlbums;
            Index = index;
        }

        public GameAlbum[] GameAlbums
        {
            get;
        }

        public int Index
        {
            get;
        }
    }
}