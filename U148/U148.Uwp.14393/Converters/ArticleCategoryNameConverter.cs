using System;
using U148.Models;
using Windows.UI.Xaml.Data;

namespace U148.Uwp.Converters
{
    public class ArticleCategoryNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ArticleCategory articleCategory)
            {
                switch (articleCategory)
                {
                    case ArticleCategory.Home:
                        return LocalizedStrings.Home;

                    case ArticleCategory.Weibo:
                        return LocalizedStrings.Weibo;

                    case ArticleCategory.Video:
                        return LocalizedStrings.Video;

                    case ArticleCategory.Image:
                        return LocalizedStrings.Image;

                    case ArticleCategory.Game:
                        return LocalizedStrings.Game;

                    case ArticleCategory.Audio:
                        return LocalizedStrings.Audio;

                    case ArticleCategory.Text:
                        return LocalizedStrings.Text;

                    case ArticleCategory.Mix:
                        return LocalizedStrings.Mix;

                    case ArticleCategory.Piao:
                        return LocalizedStrings.Piao;

                    case ArticleCategory.Fair:
                        return LocalizedStrings.Fair;

                    case ArticleCategory.Tasty:
                        return LocalizedStrings.Tasty;

                    default:
                        return value;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}