using System;
using VGtime.Models.Games;

namespace VGtime.Uwp.ViewParameters
{
    public class ImagePagerViewParameter
    {
        public ImagePagerViewParameter(GameAlbum[] photos, int photoIndex)
        {
            if (photos == null)
            {
                throw new ArgumentNullException(nameof(photos));
            }

            Photos = photos;
            PhotoIndex = photoIndex;
        }

        public GameAlbum[] Photos
        {
            get;
        }

        public int PhotoIndex
        {
            get;
            set;
        }
    }
}