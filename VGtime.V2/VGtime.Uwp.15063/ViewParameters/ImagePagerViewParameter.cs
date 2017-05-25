using System;
using VGtime.Models.Games;

namespace VGtime.Uwp.ViewParameters
{
    public class ImagePagerViewParameter
    {
        public ImagePagerViewParameter(GameAlbum[] photos, int selectedIndex)
        {
            if (photos == null)
            {
                throw new ArgumentNullException(nameof(photos));
            }

            Photos = photos;
            SelectedIndex = selectedIndex;
        }

        public GameAlbum[] Photos
        {
            get;
        }

        public int SelectedIndex
        {
            get;
            set;
        }
    }
}