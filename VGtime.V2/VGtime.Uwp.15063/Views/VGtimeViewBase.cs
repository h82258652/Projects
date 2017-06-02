using System;
using System.Numerics;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Navigation;

namespace VGtime.Uwp.Views
{
    public class VGtimeViewBase : ViewBase
    {
        protected override ContentControl PreviousPageHost
        {
            get
            {
                var rootView = Window.Current.Content as RootView;
                return rootView?.PreviousPageHost;
            }
        }

        protected override Task PlayEnterAnimationAsync()
        {
            if (ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", nameof(ElementCompositionPreview.GetElementVisual)))
            {
                if (Frame.BackStackDepth > 0
                    && Frame.CanGoForward == false)
                {
                    var visual = ElementCompositionPreview.GetElementVisual(this);
                    var compositor = visual.Compositor;
                    var tcs = new TaskCompletionSource<object>();
                    var batch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                    TypedEventHandler<object, CompositionBatchCompletedEventArgs> handler = null;
                    handler = (sender, args) =>
                    {
                        batch.Completed -= handler;
                        visual.Offset = Vector3.Zero;
                        tcs.SetResult(null);
                    };
                    batch.Completed += handler;

                    var linear = compositor.CreateLinearEasingFunction();
                    var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
                    offsetAnimation.InsertKeyFrame(0, new Vector3((float)Frame.ActualWidth, 0, 0), linear);
                    offsetAnimation.InsertKeyFrame(1, new Vector3(0, 0, 0), linear);
                    offsetAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    visual.StartAnimation(nameof(Visual.Offset), offsetAnimation);
                    batch.End();
                    return tcs.Task;
                }
            }

            return base.PlayEnterAnimationAsync();
        }

        protected override Task PlayLeaveAnimationAsync(NavigationMode currentPageNavigationMode)
        {
            if (ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", nameof(ElementCompositionPreview.GetElementVisual)))
            {
                if (currentPageNavigationMode == NavigationMode.Back)
                {
                    var visual = ElementCompositionPreview.GetElementVisual(this);
                    var compositor = visual.Compositor;
                    var tcs = new TaskCompletionSource<object>();
                    var batch = compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
                    TypedEventHandler<object, CompositionBatchCompletedEventArgs> handler = null;
                    handler = (sender, args) =>
                    {
                        batch.Completed -= handler;
                        visual.Offset = Vector3.Zero;
                        tcs.SetResult(null);
                    };
                    batch.Completed += handler;

                    var linear = compositor.CreateLinearEasingFunction();
                    var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
                    offsetAnimation.InsertKeyFrame(0, new Vector3(0, 0, 0), linear);
                    offsetAnimation.InsertKeyFrame(1, new Vector3((float)Frame.ActualWidth, 0, 0), linear);
                    offsetAnimation.Duration = TimeSpan.FromSeconds(0.3);
                    visual.StartAnimation(nameof(Visual.Offset), offsetAnimation);
                    batch.End();
                    return tcs.Task;
                }
            }

            return base.PlayLeaveAnimationAsync(currentPageNavigationMode);
        }
    }
}