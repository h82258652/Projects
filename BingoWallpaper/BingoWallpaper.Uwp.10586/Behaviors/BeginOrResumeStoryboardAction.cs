using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Microsoft.Xaml.Interactivity;
using SoftwareKobo.Extensions;

namespace BingoWallpaper.Uwp.Behaviors
{
    public class BeginOrResumeStoryboardAction : DependencyObject, IAction
    {
        public static readonly DependencyProperty StoryboardProperty = DependencyProperty.Register(nameof(Storyboard), typeof(Storyboard), typeof(BeginOrResumeStoryboardAction), new PropertyMetadata(null));

        public Storyboard Storyboard
        {
            get
            {
                return (Storyboard)GetValue(StoryboardProperty);
            }
            set
            {
                SetValue(StoryboardProperty, value);
            }
        }

        public object Execute(object sender, object parameter)
        {
            Storyboard?.BeginOrResume();
            return null;
        }
    }
}