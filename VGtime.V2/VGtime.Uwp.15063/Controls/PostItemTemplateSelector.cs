using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VGtime.Models.Timeline;

namespace VGtime.Uwp.Controls
{
    public class PostItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalTemplate
        {
            get;
            set;
        }

        public DataTemplate VideoTemplate
        {
            get;
            set;
        }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var post = (TimeLineBase)item;
            if (post.IsVideo)
            {
                return VideoTemplate;
            }
            else
            {
                return NormalTemplate;
            }
        }
    }
}