using VGtime.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            if (((Post)item).IsVideo)
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