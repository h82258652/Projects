using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = NotLoadingVisualStateName)]
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = LoadingVisualStateName)]
    public sealed class VGtimeLoadingControl : Control
    {
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(nameof(IsLoading), typeof(bool), typeof(VGtimeLoadingControl), new PropertyMetadata(default(bool), OnIsLoadingChanged));

        private const string CommonStateGroupName = "CommonStates";

        private const string LoadingVisualStateName = "Loading";

        private const string NotLoadingVisualStateName = "NotLoading";

        public VGtimeLoadingControl()
        {
            DefaultStyleKey = typeof(VGtimeLoadingControl);
        }

        public bool IsLoading
        {
            get
            {
                return (bool)GetValue(IsLoadingProperty);
            }
            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisualState();
        }

        private static void OnIsLoadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (VGtimeLoadingControl)d;

            obj.UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            if (IsLoading)
            {
                VisualStateManager.GoToState(this, LoadingVisualStateName, true);
            }
            else
            {
                VisualStateManager.GoToState(this, NotLoadingVisualStateName, true);
            }
        }
    }
}